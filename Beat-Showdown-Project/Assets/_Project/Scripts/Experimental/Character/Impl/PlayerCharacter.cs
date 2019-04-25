using UnityEngine;

namespace Experimental
{
    public class PlayerCharacter : SmartCharacter, IMovementInput, ICharacterInput, IPlayerCharacter
    {
        public PlayerInputConfig InputConfig;

        public Vector3 MoveDelta { get; set; }

        protected override void Awake()
        {
            base.Awake();
            MapInputToActions();
        }

        private void MapInputToActions()
        {
            InputConfig.Init();

            InputConfig.MoveAction.performed += context =>
            {
                var delta = context.ReadValue<Vector2>();
                MoveDelta = new Vector3(delta.x, 0, delta.y);
                OnMove?.Invoke();
            };

            InputConfig.AttackAction.performed += context => OnAttack?.Invoke();
            InputConfig.JumpAction.performed += context => OnJump?.Invoke();
            InputConfig.PickUpAction.performed += context => OnPickUp.Invoke();
        }

        private void Update()
        {
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