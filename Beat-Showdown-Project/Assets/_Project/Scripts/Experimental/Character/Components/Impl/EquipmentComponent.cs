using Experimental;
using System;
using UnityEngine;

public class EquipmentComponent : CharacterObserverBase<Animator, SmartCharacter>, IWeaponAvatar
{
    public AvatarAnchorView WeaponAvatar;
    public AvatarAnchorView PrimaryWeaponAvatar => WeaponAvatar;

    public IWeapon Weapon;

    public Action<Item> OnEquip;

    public override void Register(SmartCharacter source)
    {
        OnEquip += source.BindItemOnEquip;
    }

    public void TryEquip(Item item)
    {
        var weapon = item as IWeapon;
        if (weapon != null)
        {
            Equip(weapon);
            OnEquip?.Invoke(item);
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

        Model.runtimeAnimatorController = weapon.RuntimeAnimator;

        Weapon = weapon;
    }
}