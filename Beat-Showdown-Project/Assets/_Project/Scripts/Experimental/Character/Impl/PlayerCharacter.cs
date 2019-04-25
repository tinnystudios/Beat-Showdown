using UnityEngine;

namespace Experimental
{
    public class PlayerCharacter : SmartCharacter, IMovementInput, ICharacterInput, IPlayerCharacter
    {
        public PlayerInputConfig InputConfig;

        public Vector3 MoveDir { get; set; }

        protected override void Awake()
        {
            base.Awake();
        }

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
                OnJump?.Invoke();

            if (Input.GetKeyDown(KeyCode.E))
                OnPickUp?.Invoke();

            if (Input.GetKeyDown(KeyCode.F))
                OnAttack?.Invoke();

            OnUpdateComponents?.Invoke();
        }

        protected override void ResolveDependencies()
        {
            base.ResolveDependencies();
            this.Bind<IBind<PlayerCharacter>, PlayerCharacter>(this);
            this.Bind<IBind<IMovementInput>, IMovementInput>(this);
        }
    }
}