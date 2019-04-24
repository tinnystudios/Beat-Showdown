using App.Characters.Models;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Ability/Heal")]
public class HealAbility : AbilityBase<ICharacterStatus>
{
    public int HpValue = 3;

    public override void Use()
    {
        Response.AddHp(HpValue);
    }
}
