using App.Items.Models;
using UnityEngine;

public class ItemAssetView : MonoBehaviour, IPickable
{
    public Item ItemAsset;
    public Renderer Renderer;

    public virtual Item GetItem()
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