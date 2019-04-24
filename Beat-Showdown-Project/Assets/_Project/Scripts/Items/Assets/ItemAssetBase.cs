using UnityEngine;

/// <summary>
/// A service between Unity and MVC Agent
/// </summary>
public abstract class ItemAssetBase<T> : ItemAssetBase where T : IItemModel
{
    public T Model;
}

public abstract class ItemAssetBase : ScriptableObject, IItemAssetAgent
{
    public abstract IItemAgent CreateAgent();
}