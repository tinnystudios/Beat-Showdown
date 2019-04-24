using UnityEngine;

namespace App.Items.Models
{
    public interface IPickable : ISelectable
    {
        IItemAssetAgent PickItem();
        Transform transform { get; }
    }
}