using App.Characters.Components;
using App.Characters.Models;
using App.Characters.Views;
using App.Game.UserInput;
using UnityEngine;

namespace App.Characters.Controllers
{
    public class CharacterAgent : MonoBehaviour
    {
        public CharacterInput Input = new CharacterInput();
        public CharacterStatus Status = null;

        public CharacterView View;

        public Inventory Inventory = new Inventory();

        [Header("Components")]
        public CharacterMotion Motion;
        public CharacterCombat Combat;
        public CharacterSensory Sensory;

        public void Init()
        {
            Status = new CharacterStatus(hp: 5, maxHp: 10);
            View.Init(Status);
        }

        public void ProcessInput()
        {
            if (Input.Jump) Motion.Jump();
            if (Input.Attack) Combat.Attack();

            ProcessPickUp();
            Motion.Move(Input.Move);
        }

        private void ProcessPickUp()
        {
            var pickInterface = Sensory.FindNearestPickable(transform.position, transform.forward);

            if (Input.PickUp && pickInterface != null)
            {
                PickUp(pickInterface.PickItem());
            }
        }

        public void PickUp(IItemAssetAgent itemAssetAgent)
        {
            var agent = itemAssetAgent.CreateAgent();
        }

        public void UseItem(IItemAgent itemAgent)
        {
            itemAgent.Use();
        }

        public void BindItem(IItemAgent itemAgent)
        {
            (itemAgent as IBind<CharacterStatus>)?.Bind(Status);
        }
    }
}