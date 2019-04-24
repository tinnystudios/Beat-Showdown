using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item/Weapon")]
public class Weapon : EquipmentBase<WeaponSceneView>, IWeapon
{
    [SerializeField] private AnimatorOverrideController _RuntimeAnimator;
    [SerializeField] private EWeaponType _WeaponType;

    public WeaponSceneView WeaponPrefab => _EquipmentPrefab;
    public AnimatorOverrideController RuntimeAnimator => _RuntimeAnimator;
    public EWeaponType WeaponType => _WeaponType;

    public WeaponSceneView Instance { get; set; }

    public void Attack()
    {
        base.Use();
    }
}

public interface IWeapon
{
    EWeaponType WeaponType { get; }
    AnimatorOverrideController RuntimeAnimator { get; }
    WeaponSceneView WeaponPrefab { get; }
    WeaponSceneView Instance { get; set; }

    void Attack();
}