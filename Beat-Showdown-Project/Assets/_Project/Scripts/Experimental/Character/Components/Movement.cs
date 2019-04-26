namespace Experimental
{
    public abstract class MovementBase<T> : CharacterObserverBase<T, SmartCharacter> where T : class
    {
        public float MoveSpeed = 5;

        public override void Register(SmartCharacter smartCharacter)
        {
            smartCharacter.OnMove += Move;
        }

        public abstract void Move();
    }
}