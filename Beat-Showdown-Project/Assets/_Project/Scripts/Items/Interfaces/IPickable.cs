using UnityEngine;

namespace App.Items.Models
{
    public interface IPickable : ISelectable
    {
        ItemModel PickUp();
        Transform transform { get; }
    }
}