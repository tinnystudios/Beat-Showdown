using Experimental;
using UnityEngine;

[RequireComponent(typeof(InventoryComponent))]
public class PickUpComponent : CharacterComponentBase<InventoryComponent, SmartCharacter>
{
    public override void Activate(SmartCharacter source)
    {
        source.OnPickUp += PickUp;
    }

    private void PickUp(Item item)
    {
        Model.Add(item);
    }
}