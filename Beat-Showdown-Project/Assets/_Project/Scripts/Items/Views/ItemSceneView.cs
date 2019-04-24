using UnityEngine;

/// <summary>
/// A view for Unity Item Views
/// </summary>
public class ItemSceneView : MonoBehaviour, IItemView
{
    public void Exit()
    {
        Destroy(gameObject);
    }

    public void SetAvatar(IAvatarAnchor anchor)
    {
        transform.position = anchor.transform.position;
        transform.rotation = anchor.transform.rotation;

        transform.SetParent(anchor.transform);
    }
}
