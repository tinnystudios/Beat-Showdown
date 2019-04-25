using Experimental;
using System;
using UnityEngine;

[RequireComponent(typeof(EquipmentComponent))]
public class InventoryComponent : CharacterComponentBase<EquipmentComponent, SmartCharacter>
{
    public Action<Item> OnItemPickUp;

    public override void Activate(SmartCharacter source)
    {
        OnItemPickUp += source.BindItemOnPickUp;
    }

    public void Add(Item item)
    {
        OnItemPickUp?.Invoke(item);
        (item as IConsumerable)?.Use();
        Model.TryEquip(item);
    }
}