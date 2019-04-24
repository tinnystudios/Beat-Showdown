using UnityEngine;

[CreateAssetMenu(menuName ="Game/Item/Sword")]
public class SwordAsset : ItemAssetBase<SwordModel>
{
    public override IItemAgent CreateAgent()
    {
        return new SwordAgent(Model);
    }
}
