using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item/Weapon")]
public class Weapon : EquipmentBase<WeaponSceneView>, IWeapon
{
    [SerializeField] private AnimatorOverrideController _RuntimeAnimator;

    public WeaponSceneView WeaponPrefab => _EquipmentPrefab;
    public AnimatorOverrideController RuntimeAnimator => _RuntimeAnimator;
    public WeaponSceneView Instance { get; set; }

    public void Attack()
    {
        base.Use();
    }
}

public interface IWeapon
{
    AnimatorOverrideController RuntimeAnimator { get; }
    WeaponSceneView WeaponPrefab { get; }
    WeaponSceneView Instance { get; set; }

    void Attack();
}