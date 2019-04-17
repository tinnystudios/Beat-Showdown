using System;
using UnityEngine;

namespace App.Items.Models
{
    [Serializable]
    public class GunModel : IWeaponModel
    {
        public int Power = 10;
        public GameObject BulletPrefab;
    }
}