using System;

public interface ICharacterEquipment
{
    Action<IWeaponAgent> OnEquip { get; set; }
    Action<IWeaponAgent> OnUnequip { get; set; }

    IWeaponAgent WeaponAgent { get; }
}