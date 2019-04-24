using UnityEngine;
/// <summary>
/// Presently only used for creating a Scene Object, however it can also set individual UI
/// </summary>
public interface IItemView
{
    void SetAvatar(IAvatarAnchor anchor);
    void Exit();
    Transform transform { get; }
    GameObject gameObject { get; }
}