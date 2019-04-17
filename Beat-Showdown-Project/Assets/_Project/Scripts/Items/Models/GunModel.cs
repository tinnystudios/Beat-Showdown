using System;
using UnityEngine;

namespace App.Items.Models
{
    [Serializable]
    public class GunModel : IWeapon, IItemModel
    {
        public int Power = 10;
        public GameObject BulletPrefab;
    }
}