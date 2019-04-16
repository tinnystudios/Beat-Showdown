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

        [Header("Components")]
        public CharacterMotion Motion;
        public CharacterCombat Combat;

        public void Init()
        {
            Status = new CharacterStatus(hp: 10, maxHp: 10);
            View.Init(Status);
        }

        private void Update()
        {
            ProcessInput();
        }

        public void ProcessInput()
        {
            if (Input.Jump) Motion.Jump();
            if (Input.Attack) Combat.Attack();

            Motion.Move(Input.Move);
        }

        private void TakeDamage()
        {
            Status.DeductHp(1);
        }
    }
}