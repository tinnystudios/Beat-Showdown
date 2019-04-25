using System;
using UnityEngine;

[Serializable]
public class SimpleAvatar : IWeaponAvatar
{
    [SerializeField] private AvatarAnchorView _PrimaryWeapon;
    public AvatarAnchorView PrimaryWeaponAvatar => _PrimaryWeapon;
}
