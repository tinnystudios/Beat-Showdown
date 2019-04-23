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

        public virtual void ProcessInput()
        {
            ProcessJumpInput();
            ProcessCombatInput();
            ProcessMotionInput();
            ProcessPickUp();
        }

        public virtual void ProcessJumpInput()
        {
            if (Input.Jump) Motion.Jump();
        }

        public virtual void ProcessMotionInput()
        {
            Motion.Move(Input.Move);
        }

        public virtual void ProcessCombatInput()
        {

        }

        public virtual void ProcessPickUp()
        {
            var pickInterface = Sensory.FindNearestPickable(transform.position, transform.forward);

            if (Input.PickUp && pickInterface != null)
            {
                PickUp(pickInterface.PickItem());
            }
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