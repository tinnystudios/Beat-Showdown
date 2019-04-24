using System;
using UnityEngine;

[Serializable]
public class HumanAvatar : IHumanAvatar
{
    [SerializeField] private AvatarAnchorView _leftHand;
    [SerializeField] private AvatarAnchorView _rightHand;
    [SerializeField] private AvatarAnchorView _head;

    public AvatarAnchorView LeftHand => _leftHand;
    public AvatarAnchorView RightHand => PrimaryWeapon;
    public AvatarAnchorView Head => _head;

    public AvatarAnchorView PrimaryWeapon => _rightHand;
}

public interface IHumanAvatar : ICharacterAvatar
{
    AvatarAnchorView LeftHand { get; }
    AvatarAnchorView RightHand { get; }
    AvatarAnchorView Head { get; }
}