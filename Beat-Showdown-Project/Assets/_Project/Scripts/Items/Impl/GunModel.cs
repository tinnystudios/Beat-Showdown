using UnityEngine;

namespace App.Items.Models
{
    public class GunModel : ItemModel, IWeapon
    {
        public override void Use()
        {
            Debug.Log("Shoot with Gun");
        }
    }
}