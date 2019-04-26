namespace Experimental
{
    public interface IObserver<T>
    {
        void Register(T character);
    }

    public interface ICharacter
    {

    }
}