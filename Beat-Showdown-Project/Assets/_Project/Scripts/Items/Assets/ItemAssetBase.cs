using UnityEngine;

/// <summary>
/// A service between Unity and MVC Agent
/// </summary>
public abstract class ItemAssetBase<T> : ScriptableObject, IItemAssetAgent where T : IItemModel
{
    public T Model;

    protected ItemAssetBase(T model)
    {
        Model = model;
    }

    public abstract IItemAgent CreateAgent();
    public IItemModel ItemModel => Model;
}