using System;

public interface IPickableAgent
{
    Action<Item> OnPickUp { get; set; }
    void PickUp(Item item);
}