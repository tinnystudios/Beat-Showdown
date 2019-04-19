using System;

namespace App.Items.Models
{
    [Serializable]
    public class GunModel : IWeaponModel
    {
        public int Power = 10;
        public GunView Prefab;
        public BulletComponent BulletPrefab;
    }
}