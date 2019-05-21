using UnityEngine;

namespace Experimental
{
    public class BeatCharacter : PlayerCharacter
    {
        [Header("Beat")]
        public BeatMeterAgent BeatMeterAgent;
        public BeatCondition BeatCondition;

    }

    public class PlayerCharacter : SmartCharacter, IMovementInput, ICharacterInput, IPlayerCharacter
    {
        public PlayerInputConfig InputConfig;
        public Vector3 MoveDelta { get; set; }

        protected override void Awake()
        {
            base.Awake();
            MapInputToActions();
        }

        protected virtual void MapInputToActions()
        {
            InputConfig.Init();

            InputConfig.MoveAction.performed += context =>
            {
                var delta = context.ReadValue<Vector2>();
                MoveDelta = new Vector3(delta.x, 0, delta.y);
                OnMove?.Invoke();
            };

            InputConfig.AttackAction.performed += context => Attack();
            InputConfig.JumpAction.performed += context => Jump();
            InputConfig.PickUpAction.performed += context => PickUp();
        }

        protected virtual void Attack()
        {
            OnAttack?.Invoke();
        }

        protected virtual void Jump()
        {
            OnJump?.Invoke();
        }

        protected virtual void PickUp()
        {
            OnPickUp?.Invoke();
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