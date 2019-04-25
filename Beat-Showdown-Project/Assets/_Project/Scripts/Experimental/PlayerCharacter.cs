using UnityEngine;

namespace Experimental
{
    public class PlayerCharacter : SmartCharacter, IMovementInput, ICharacterInput
    {
        // Temp
        public Item Item;
        public Vector3 MoveDir { get; set; }

        public void OnUserMove(Vector3 joystick)
        {
            MoveDir = joystick;
            OnMove?.Invoke();
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            OnUserMove(new Vector3(x, 0, z));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                OnPickUp?.Invoke(Item);
            }

            if (Input.GetKeyDown(KeyCode.F))
                OnAttack?.Invoke();
        }

        protected override void ResolveDependencies()
        {
            base.ResolveDependencies();
            this.Bind<IBind<PlayerCharacter>, PlayerCharacter>(this);
            this.Bind<IBind<IMovementInput>, IMovementInput>(this);
        }
    }
}