using App.Items.Models;
using Experimental;
using UnityEngine;

[RequireComponent(typeof(InventoryComponent))]
public class PickUpComponent : CharacterComponentBase<InventoryComponent, SmartCharacter>
{
    public LayerMask PickableLayer;
    public PickableSensor Sensor;

    private IPickable _pickInterface;

    public override void Activate(SmartCharacter source)
    {
        Sensor = new PickableSensor(PickableLayer, transform);

        source.OnPickUp += TryPickUp;
        source.OnUpdateComponents += Sense;
    }

    private void Sense()
    {
        _pickInterface = Sensor.FindNearestPickable(transform.position, transform.forward);
    }

    private void TryPickUp()
    {
        if (_pickInterface != null)
        {
            PickUp(_pickInterface.GetItem());
        }
    }

    private void PickUp(Item item)
    {
        Model.Add(item.Clone());
    }
}