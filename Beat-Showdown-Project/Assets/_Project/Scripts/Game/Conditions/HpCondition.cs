using App.Characters.Models;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Condition/HpCondition")]
public class HpCondition : ConditionBase<CharacterStatus>
{
    public int HpRequired;
    public override bool Pass => Value.Hp > HpRequired;
}
