using UnityEngine;

public abstract class EquipmentBase<T> : Item where T : ItemSceneView
{
    [SerializeField] protected T _EquipmentPrefab;
}