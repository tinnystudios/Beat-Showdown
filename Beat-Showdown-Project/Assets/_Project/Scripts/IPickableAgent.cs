using System;

public interface IPickableAgent
{
    Action<IItemAgent> OnPickUp { get; set; }
    void PickUp(IItemAssetAgent itemAssetAgent);
}