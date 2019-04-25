using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item/Item")]
public class Item : ItemBase
{
    public string Name = "Default";
    public List<AbilityBase> Abilities = new List<AbilityBase>();

    public Item Clone()
    {
        var newAbilities = new List<AbilityBase>();

        foreach (var ability in Abilities)
        {
            var newAbility = Instantiate(ability);
            newAbilities.Add(newAbility);
        }

        var clone = Instantiate(this);
        clone.Abilities = newAbilities;

        return clone;
    }

    public override void Use()
    {
        foreach (var ability in Abilities)
        {
            ability.Use();
        }

        Debug.Log("Used: " + name);
    }
}
