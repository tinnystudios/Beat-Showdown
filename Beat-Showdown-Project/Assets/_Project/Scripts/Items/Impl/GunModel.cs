using UnityEngine;

namespace App.Items.Models
{
    [CreateAssetMenu(menuName = "Game/Item/Gun")]
    public class GunModel : ItemModel, IWeapon
    {
        public override void Use()
        {
            Debug.Log("Shoot with Gun");
        }
    }
}