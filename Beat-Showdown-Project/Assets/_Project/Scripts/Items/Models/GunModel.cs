using System;

namespace App.Items.Models
{
    [Serializable]
    public class GunModel : EquipmentModel<GunView>, IWeaponModel
    {
        public int Power = 10;
        public BulletComponent BulletPrefab;
    }
}