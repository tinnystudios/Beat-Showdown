using App.Characters.Models;
using App.Game.UserInput;

namespace App.Characters.Controllers
{
    public class PlayerCharacterAgent : CharacterAgent, IPlayerCharacterAgent
    {
        public CharacterInput Input = new CharacterInput();
        public AvatarAnchorView HandAnchor;

        private IItemAgent _weaponAgent; //Change this to a weapon interface soon

        public void ProcessInput()
        {
            if (Input.Jump) Motion.Jump();
            if (Input.Attack) Combat.Attack();

            ProcessPickUp();
            Motion.Move(Input.Move);
        }

        public void ProcessPickUp()
        {
            var pickInterface = Sensory.FindNearestPickable(transform.position, transform.forward);

            if (Input.PickUp && pickInterface != null)
            {
                PickUp(pickInterface.PickItem());
            }
        }

        public void PickUp(IItemAssetAgent itemAssetAgent)
        {
            var itemAgent = itemAssetAgent.CreateAgent();

            BindItem((itemAgent));
            (itemAgent as IConsumableAgent)?.Use();

            var weapon = itemAgent as IWeaponAgent;
            if (weapon != null)
                Equip(itemAgent);

            Inventory.Add(itemAgent);
        }

        public void UseItem(IItemAgent itemAgent)
        {
            itemAgent.Use();
        }

        public void Equip(IItemAgent itemAgent)
        {
            if (_weaponAgent != null)
                UnEquip(_weaponAgent);

            itemAgent.View().SetAvatar(HandAnchor);
            _weaponAgent = itemAgent;

            Combat.SetWeapon(_weaponAgent);
        }

        public void UnEquip(IItemAgent itemAgent)
        {
            itemAgent.View().Exit();
        }

        public void BindItem(IItemAgent itemAgent)
        {
            (itemAgent as IBind<CharacterStatus>)?.Bind(Status);
        }
    }
}