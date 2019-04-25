using App.Items.Models;
using UnityEngine;

public class ItemAssetView : MonoBehaviour, IPickable
{
    public Item ItemAsset;

    private Renderer[] _renderer;

    private void Awake()
    {
        _renderer = GetComponentsInChildren<Renderer>();
        Deselect();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, 10 * Time.deltaTime);
    }

    public virtual Item GetItem()
    {
        gameObject.SetActive(false);
        return ItemAsset;
    }

    public virtual void Select()
    {
        foreach (var r in _renderer)
            r.material.color = Color.blue;
    }

    public virtual void Deselect()
    {
        foreach (var r in _renderer)
            r.material.color = Color.black;
    }
}