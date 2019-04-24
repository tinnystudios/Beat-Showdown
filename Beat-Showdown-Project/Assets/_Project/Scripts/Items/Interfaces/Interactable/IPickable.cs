using UnityEngine;

namespace App.Items.Models
{
    public interface IPickable : ISelectable
    {
        Item GetItem();
        Transform transform { get; }
    }
}