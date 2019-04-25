using App.Characters.Controllers;
using App.Items.Models;
using Experimental;
using UnityEngine;

[RequireComponent(typeof(InventoryComponent))]
public class PickUpComponent : CharacterComponentBase<InventoryComponent, SmartCharacter>
{
    public CharacterSensory Sensory;
    private IPickable _pickInterface;

    public override void Activate(SmartCharacter source)
    {
        source.OnPickUp += TryPickUp;
    }

    private void Update()
    {
        _pickInterface = Sensory.FindNearestPickable(transform.position, transform.forward);
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
        Model.Add(item);
    }
}