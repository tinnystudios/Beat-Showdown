using UnityEngine;

namespace App.Items.Models
{
    public class Potion : ItemModel, IConsumable
    {
        public override void Use()
        {
            Debug.Log("Use Potion");
        }
    }
}