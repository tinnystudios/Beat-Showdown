public abstract class ItemAgent<T> : IItemAgent
{
    public T Model { get; set; }

    protected ItemAgent(T model)
    {
        Model = model;
    }

    public abstract void Use();
}