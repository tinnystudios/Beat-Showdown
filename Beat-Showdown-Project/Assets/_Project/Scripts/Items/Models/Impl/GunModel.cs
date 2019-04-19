using System;

namespace App.Items.Models
{
    [Serializable]
    public class GunModel : EquipmentBaseModel<GunView>, IWeaponModel
    {
        public int Power = 10;
        public BulletComponent BulletPrefab;
    }
}