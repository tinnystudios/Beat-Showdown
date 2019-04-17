using UnityEngine;

namespace App.Items.Models
{
    public interface IPickable
    {
        ItemModel PickUp();
        void Highlight();
        void Deselect();
        Transform transform { get; }
    }
}