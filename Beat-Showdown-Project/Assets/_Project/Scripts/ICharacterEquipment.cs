using System;

public interface ICharacterEquipment
{
    Action<IWeapon> OnEquip { get; set; }
    Action<IWeapon> OnUnequip { get; set; }

    IWeapon WeaponAgent { get; }

    void TryEquip(Item item);
}