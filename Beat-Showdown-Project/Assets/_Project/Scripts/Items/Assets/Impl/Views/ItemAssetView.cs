using App.Items.Models;
using UnityEngine;

public abstract class ItemAssetView<T> : MonoBehaviour, IPickable where T : IItemAssetAgent
{
    public T ItemAsset;
    public Renderer Renderer;

    public virtual IItemAssetAgent PickItem()
    {
        gameObject.SetActive(false);
        return ItemAsset;
    }

    public virtual void Select()
    {
        Renderer.material.color = Color.blue;
    }

    public virtual void Deselect()
    {
        Renderer.material.color = Color.white;
    }
}