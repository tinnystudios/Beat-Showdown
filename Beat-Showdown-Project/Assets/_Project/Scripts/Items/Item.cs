using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Item/Item")]
public class Item : ItemBase
{
    public string Name = "Default";
    public List<AbilityBase> Abilities = new List<AbilityBase>();

    public override void Use()
    {
        foreach (var ability in Abilities)
        {
            ability.Use();
        }

        Debug.Log("Used: " + name);
    }
}
