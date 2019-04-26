using Experimental;
using System;
using UnityEngine;

[RequireComponent(typeof(EquipmentComponent))]
public class InventoryComponent : CharacterObserverBase<EquipmentComponent, SmartCharacter>
{
    public Action<Item> OnItemPickUp;

    public override void Register(SmartCharacter source)
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