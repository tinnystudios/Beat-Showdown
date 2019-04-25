using UnityEngine;

public class EquipmentComponent : MonoBehaviour, IWeaponAvatar, IBind<Animator>
{
    public AvatarAnchorView WeaponAvatar;
    public AvatarAnchorView PrimaryWeaponAvatar => WeaponAvatar;

    public IWeapon Weapon;

    private Animator _animator;

    public void Bind(Animator animator) { _animator = animator; }

    public void TryEquip(Item item)
    {
        var weapon = item as IWeapon;
        if (weapon != null)
        {
            Equip(weapon);
            BindDependencies(item, weapon);
        }
    }

    public void Equip(IWeapon weapon)
    {
        if (Weapon != null)
            Weapon.Instance.Exit();

        var pivot = PrimaryWeaponAvatar.transform;
        var weaponInstance = Instantiate(weapon.WeaponPrefab);

        weapon.Instance = weaponInstance;
        weaponInstance.SetAvatar(PrimaryWeaponAvatar);

        _animator.runtimeAnimatorController = weapon.RuntimeAnimator;

        Weapon = weapon;
    }

    public void BindDependencies(Item item, IWeapon weapon)
    {
        foreach (var ability in item.Abilities)
        {
            (ability as IBind<IShootLocation>)?.Bind(weapon.Instance.Pivot);
        }
    }
}