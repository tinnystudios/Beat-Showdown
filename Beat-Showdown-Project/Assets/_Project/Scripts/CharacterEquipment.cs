using System;
using UnityEngine;

public class CharacterEquipment<T> : MonoBehaviour, IBind<IPickableAgent>, ICharacterEquipment where T : ICharacterAvatar
{
    public T Avatar;

    public Action<IWeapon> OnEquip { get; set; }
    public Action<IWeapon> OnUnequip { get; set; }

    public IWeapon WeaponAgent { get; private set; }

    public void Bind(IPickableAgent pickableAgent) { pickableAgent.OnPickUp += TryEquip; }

    public void TryEquip(Item item)
    {
        var weapon = item as IWeapon;
        if (weapon != null)
        {
            Equip(weapon);
            BindDependencies(item, weapon);
        }
    }

    public void BindDependencies(Item item, IWeapon weapon)
    {
        foreach (var ability in item.Abilities)
        {
            (ability as IBind<IShootLocation>)?.Bind(weapon.Instance.Pivot);
        }
    }

    public void Equip(IWeapon weapon)
    {
        if (WeaponAgent != null)
            UnEquip(WeaponAgent);

        var weaponAnchorTransform = Avatar.PrimaryWeapon.transform;
        var weaponInstance = Instantiate(weapon.WeaponPrefab, weaponAnchorTransform.position, weaponAnchorTransform.rotation);

        weaponInstance.transform.SetParent(weaponAnchorTransform);
        weapon.Instance = weaponInstance;

        WeaponAgent = weapon;
        
        OnEquip?.Invoke(WeaponAgent);
    }

    public void UnEquip(IWeapon weapon)
    {
        Destroy(weapon.Instance.gameObject);
    }
}
