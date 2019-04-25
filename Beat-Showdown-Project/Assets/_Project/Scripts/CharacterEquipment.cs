using System;
using UnityEngine;

public class CharacterEquipment<T> : MonoBehaviour, IBind<IPickableAgent>, ICharacterEquipment where T : ICharacterAvatar
{
    public T Avatar;

    public Action<IWeaponAgent> OnEquip { get; set; }
    public Action<IWeaponAgent> OnUnequip { get; set; }

    public IWeaponAgent WeaponAgent { get; private set; }

    public void Bind(IPickableAgent pickableAgent) { pickableAgent.OnPickUp += TryEquip; }

    public void TryEquip(IItemAgent itemAgent)
    {
        var weapon = itemAgent as IWeaponAgent;
        if (weapon != null)
            Equip(weapon);
    }

    public void Equip(IWeaponAgent weaponAgent)
    {
        if (WeaponAgent != null)
            UnEquip(WeaponAgent);

        weaponAgent.View().SetAvatar(Avatar.PrimaryWeapon);
        WeaponAgent = weaponAgent;

        OnEquip?.Invoke(WeaponAgent);
    }

    public void UnEquip(IWeaponAgent itemAgent)
    {
        itemAgent.View().Exit();
    }
}
