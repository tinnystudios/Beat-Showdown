namespace Experimental
{
    public abstract class MovementBase<T> : CharacterComponentBase<T, SmartCharacter> where T : class
    {
        public float MoveSpeed = 5;

        public override void Activate(SmartCharacter smartCharacter)
        {
            smartCharacter.OnMove += Move;
        }

        public abstract void Move();
    }
}