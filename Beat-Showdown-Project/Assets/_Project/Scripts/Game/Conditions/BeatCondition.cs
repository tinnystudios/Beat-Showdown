using UnityEngine;

[CreateAssetMenu(menuName = "Game/Condition/Beat")]
public class BeatCondition : ConditionBase<BeatMeterAgent>
{
    // The passing value has a window of 20% into the next beat and 40% before the beat
    public override bool Pass => Value.Progress > 0.6F || Value.Progress < 0.3F;
}
