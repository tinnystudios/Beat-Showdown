using UnityEngine;

/// <summary>
/// A service between Unity and MVC Agent
/// </summary>
public abstract class ItemAssetBase<T> : ScriptableObject, IItemAssetAgent where T : IItemModel
{
    public T Model;
    public abstract IItemAgent CreateAgent();
}