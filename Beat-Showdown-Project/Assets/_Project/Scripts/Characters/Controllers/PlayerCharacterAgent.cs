using App.Characters.Components;
using App.Characters.Models;
using App.Game.UserInput;
using UnityEngine;

namespace App.Characters.Controllers
{
    public class PlayerCharacterAgent : CharacterAgent, IPlayerCharacterAgent
    {
        [Header("Components")]
        public CharacterMotion Motion;
        public CharacterCombat Combat;
        public CharacterSensory Sensory;

        public CharacterInput Input = new CharacterInput();
        public CharacterEquipment Equipment;

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
            TryEquip(itemAgent);
        }

        private void TryEquip(IItemAgent itemAgent)
        {
            var weapon = itemAgent as IWeaponAgent;
            if (weapon != null)
                Equipment.Equip(weapon);
        }

        public void UseItem(IItemAgent itemAgent)
        {
            itemAgent.Use();
        }

        public void BindItem(IItemAgent itemAgent)
        {
            (itemAgent as IBind<CharacterStatus>)?.Bind(Status);
            (itemAgent as IBind<CharacterCombat>)?.Bind(Combat);
        }
    }
}