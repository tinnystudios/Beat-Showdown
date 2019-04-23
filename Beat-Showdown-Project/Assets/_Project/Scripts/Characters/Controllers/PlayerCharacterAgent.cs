using App.Characters.Components;
using App.Characters.Models;
using App.Items.Models;
using UnityEngine;
using UnityEngine.Experimental.Input;

namespace App.Characters.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerCharacterAgent : CharacterAgent, IPlayerCharacterAgent
    {
        [Header("Components")]
        public CharacterMotion Motion;
        public CharacterCombat Combat;
        public CharacterSensory Sensory;
        public CharacterEquipment Equipment;
        public CharacterAnimator Animator;

        [Header("Configs")]
        public PlayerInputConfig InputConfig;

        private IPickable _pickInterface;

        public override void Init()
        {
            MapInput();
            BindCharacterComponents();
        }

        private void MapInput()
        {
            InputConfig.Init();
            InputConfig.MoveAction.performed += OnMove;
            InputConfig.AttackAction.performed += context => Combat.Attack();
            InputConfig.JumpAction.performed += context => Motion.Jump();
            InputConfig.PickUpAction.performed += context =>
            {
                if (_pickInterface != null)
                    PickUp(_pickInterface.PickItem());
            };
        }

        private void BindCharacterComponents()
        {
            this.Bind<IBind<ICharacterCombat>, ICharacterCombat>(Combat);
            this.Bind<IBind<ICharacterEquipment>, ICharacterEquipment>(Equipment);
            this.Bind<IBind<ICharacterAnimator>, ICharacterAnimator>(Animator);
            this.Bind<IBind<ICharacterAgent>, ICharacterAgent>(this);
            this.Bind<IBind<Rigidbody>, Rigidbody>(GetComponent<Rigidbody>());
            this.Bind<IBind<ICharacterStatus>, ICharacterStatus>(Status);
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var delta = context.ReadValue<Vector2>();
            var dir = new Vector3(delta.x, 0, delta.y);

            Motion.Move(dir);
        }

        public virtual void ProcessInput()
        {
            ProcessPickUp();
        }

        public virtual void ProcessPickUp()
        {
            _pickInterface = Sensory.FindNearestPickable(transform.position, transform.forward);
        }

        public virtual void PickUp(IItemAssetAgent itemAssetAgent)
        {
            var itemAgent = itemAssetAgent.CreateAgent();

            BindItem((itemAgent));
            (itemAgent as IConsumableAgent)?.Use();
            TryEquip(itemAgent);
        }

        public virtual void TryEquip(IItemAgent itemAgent)
        {
            var weapon = itemAgent as IWeaponAgent;
            if (weapon != null)
                Equipment.Equip(weapon);
        }

        public virtual void UseItem(IItemAgent itemAgent)
        {
            itemAgent.Use();
        }

        public virtual void BindItem(IItemAgent itemAgent)
        {
            (itemAgent as IBind<CharacterStatus>)?.Bind(Status);
            (itemAgent as IBind<CharacterCombat>)?.Bind(Combat);
        }
    }
}