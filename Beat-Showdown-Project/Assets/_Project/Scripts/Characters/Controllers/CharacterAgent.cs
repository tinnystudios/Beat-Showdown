using App.Characters.Components;
using App.Characters.Models;
using App.Characters.Views;
using App.Game.UserInput;
using App.Items.Models;
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

        public void Init()
        {
            Status = new CharacterStatus(hp: 5, maxHp: 10);
            View.Init(Status);
        }

        public void ProcessInput()
        {
            if (Input.Jump) Motion.Jump();
            if (Input.Attack) Combat.Attack();

            if (Input.PickUp)
            {
                var ray = new Ray(transform.position, transform.forward);
                if (Physics.SphereCast(ray, 1, out var hit, 1))
                {
                    var pickInterface = hit.transform.GetComponent<IPickable>();
                    if (pickInterface != null)
                    {
                        var itemModel = pickInterface.PickUp();
                        Inventory.Add(itemModel);
                    }
                }
            }

            Motion.Move(Input.Move);
        }

        public void TakeDamage()
        {
            Status.DeductHp(1);
        }
    }
}