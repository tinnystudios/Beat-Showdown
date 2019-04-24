using UnityEngine;

/// <summary>
/// A service between Unity and MVC Agent
/// </summary>
public abstract class ItemAssetBase<T> : ItemAssetBase, IItemAssetAgent where T : IItemModel
{
    public T Model;
}

public abstract class ItemAssetBase : ScriptableObject
{
    public abstract IItemAgent CreateAgent();
}