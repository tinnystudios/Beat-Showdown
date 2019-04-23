using System;
using UnityEngine;

[Serializable]
public class CharacterAvatar : ICharacterAvatar
{
    [SerializeField] private AvatarAnchorView _leftHand;
    [SerializeField] private AvatarAnchorView _rightHand;
    [SerializeField] private AvatarAnchorView _head;

    public AvatarAnchorView LeftHand => _leftHand;
    public AvatarAnchorView RightHand => _rightHand;
    public AvatarAnchorView Head => _head;
}