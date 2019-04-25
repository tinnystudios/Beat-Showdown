using Experimental;
using UnityEngine;

[RequireComponent(typeof(EquipmentComponent))]
public class InventoryComponent : CharacterComponentBase<EquipmentComponent, SmartCharacter>
{
    public override void Activate(SmartCharacter source)
    {

    }

    public void Add(Item item)
    {
        Model.TryEquip(item);
    }
}
