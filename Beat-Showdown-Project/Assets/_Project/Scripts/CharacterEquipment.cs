using System;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour, ICharacterEquipment
{
    public CharacterAvatar Avatar;

    public Action<IWeaponAgent> OnEquip { get; set; }
    public Action<IWeaponAgent> OnUnequip { get; set; }

    public IWeaponAgent WeaponAgent { get; private set; }

    public void Equip(IWeaponAgent weaponAgent)
    {
        if (WeaponAgent != null)
            UnEquip(WeaponAgent);

        weaponAgent.View().SetAvatar(Avatar.RightHand);
        WeaponAgent = weaponAgent;

        OnEquip?.Invoke(WeaponAgent);
    }

    public void UnEquip(IWeaponAgent itemAgent)
    {
        itemAgent.View().Exit();
    }
}