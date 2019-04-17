using UnityEngine;

namespace App.Items.Models
{
    public class SwordModel : ItemModel, IWeapon
    {
        public override void Use()
        {
            Debug.Log("Swing Sword");
        }
    }
}
