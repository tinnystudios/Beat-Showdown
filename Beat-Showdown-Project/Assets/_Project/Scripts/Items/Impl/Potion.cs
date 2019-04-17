using UnityEngine;

namespace App.Items.Models
{
    [CreateAssetMenu(menuName = "Game/Item/Consumable")]
    public class Potion : ItemModel, IConsumable
    {
        public override void Use()
        {
            Debug.Log("Use Potion");
        }
    }
}