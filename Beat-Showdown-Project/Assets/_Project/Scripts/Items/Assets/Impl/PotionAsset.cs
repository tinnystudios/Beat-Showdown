using Assets._Project.Scripts.Items;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item/Consumable")]
public class PotionAsset : ItemAsset<PotionModel>
{
    public PotionAsset(PotionModel model) : base(model)
    {

    }

    public override IItemAgent CreateAgent()
    {
        return new PotionAgent(Model);
    }
}