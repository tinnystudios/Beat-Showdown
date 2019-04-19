public abstract class ItemBaseAgent<T> : IItemAgent
{
    public T Model { get; set; }

    protected ItemBaseAgent(T model)
    {
        Model = model;
    }

    public abstract void Use();
    public abstract IItemView View();
}