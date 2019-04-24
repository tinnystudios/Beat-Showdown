using App.Items.Models;
using UnityEngine;

public class MockItemAssetView : MonoBehaviour, IPickable
{
    public Item Item;
    public Renderer Renderer;

    public virtual Item GetItem()
    {
        gameObject.SetActive(false);
        return Item;
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