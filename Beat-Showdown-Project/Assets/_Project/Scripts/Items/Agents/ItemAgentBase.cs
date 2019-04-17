public abstract class ItemAgentBase<T> : IItemAgent
{
    public T Model { get; set; }

    protected ItemAgentBase(T model)
    {
        Model = model;
    }

    public abstract void Use();
}