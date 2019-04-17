using App.Items.Models;
using UnityEngine;

/// <summary>
/// A view for the physical item in the scene
/// </summary>
public class ItemView : MonoBehaviour, IPickable
{
    public ItemModel ItemModel;
    public Renderer Renderer;

    public ItemModel PickUp()
    {
        gameObject.SetActive(false);
        return ItemModel;
    }

    public void Highlight()
    {
        Renderer.material.color = Color.blue;
    }

    public void Deselect()
    {
        Renderer.material.color = Color.white;
    }
}