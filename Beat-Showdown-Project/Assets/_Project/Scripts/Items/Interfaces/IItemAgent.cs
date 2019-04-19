using UnityEngine;

public interface IItemAgent
{
    IItemView View();
    void Use();
}

public interface IItemView
{
    void SetAvatar(IAvatarAnchor anchor);
    void Exit();
    Transform transform { get; }
    GameObject gameObject { get; }
}

public interface IAvatarAnchor
{
    Transform transform { get; }
}