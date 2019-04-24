using System;
using UnityEngine;

[Serializable]
public class SimpleAvatar : ICharacterAvatar
{
    [SerializeField] private AvatarAnchorView _PrimaryWeapon;
    public AvatarAnchorView PrimaryWeapon => _PrimaryWeapon;
}
