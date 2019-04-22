using UnityEngine;

[CreateAssetMenu(menuName = "Game/Condition/Beat")]
public class BeatCondition : ConditionBase<BeatMeterAgent>
{
    public override bool Pass => Value.Progress > 0.5F;
}
