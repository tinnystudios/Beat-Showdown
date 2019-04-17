using UnityEngine;

namespace App.Items.Models
{
    [CreateAssetMenu(menuName = "Game/Item/Sword")]
    public class SwordModel : ItemModel, IWeapon
    {
        public override void Use()
        {
            Debug.Log("Swing Sword");
        }
    }
}
