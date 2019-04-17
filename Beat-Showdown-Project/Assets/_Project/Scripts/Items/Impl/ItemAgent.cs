using App.Items.Models;
using UnityEngine;

/// <summary>
/// A view for the physical item in the scene
/// </summary>
public class ItemView : MonoBehaviour, IPickable
{
    public ItemModel ItemModel;

    public ItemModel PickUp()
    {
        return ItemModel;
    }

    public void Highlight()
    {

    }
}