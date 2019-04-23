using App.Characters.Components;
using App.Characters.Models;
using App.Items.Models;
using System;
using UnityEngine;

namespace App.Characters.Controllers
{
    public class PlayerCharacterAgent : CharacterAgent, IPlayerCharacterAgent, IPickableAgent
    {
        [Header("Configs")]
        public PlayerInputConfig InputConfig;
        private IPickable _pickInterface;

        public Action<IItemAgent> OnPickUp { get; set; }

        public override void Init()
        {
            OnPickUp += Equipment.TryEquip;

            base.Init();
            MapInput();
        }

        private void MapInput()
        {
            InputConfig.Init();
            InputConfig.MoveAction.performed += context => 
            {
                var delta = context.ReadValue<Vector2>();
                var dir = new Vector3(delta.x, 0, delta.y);
                Motion.Move(dir);
            };
            InputConfig.AttackAction.performed += context => Combat.Attack();
            InputConfig.JumpAction.performed += context => Motion.Jump();
            InputConfig.PickUpAction.performed += context =>
            {
                if (_pickInterface != null)
                    PickUp(_pickInterface.PickItem());
            };
        }

        public virtual void Process()
        {
            _pickInterface = Sensory.FindNearestPickable(transform.position, transform.forward);
        }

        public virtual void PickUp(IItemAssetAgent itemAssetAgent)
        {
            var itemAgent = itemAssetAgent.CreateAgent();

            BindItem((itemAgent));
            GetInterface<IConsumableAgent>(itemAgent)?.Use();

            OnPickUp?.Invoke(itemAgent);
        }

        public virtual void UseItem(IItemAgent itemAgent)
        {
            itemAgent.Use();
        }

        public virtual void BindItem(IItemAgent itemAgent)
        {
            GetInterface<IBind<ICharacterStatus>>(itemAgent)?.Bind(Status);
            GetInterface<IBind<ICharacterCombat>>(itemAgent)?.Bind(Combat);
        }

        public T GetInterface<T>(IItemAgent itemAgent) where T : class
        {
            return itemAgent as T;
        }
    }
}