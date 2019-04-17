using UnityEngine;

namespace App.Items.Models
{
    public abstract class ItemModel : ScriptableObject
    {
        public abstract void Use();
    }
}