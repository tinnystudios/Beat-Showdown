using App.Characters.Components;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public CharacterCombat Combat;
    public AvatarAnchorView HandAnchor;

    private IWeaponAgent _weaponAgent; //Change this to a weapon interface soon

    public void Equip(IWeaponAgent weaponAgent)
    {
        if (_weaponAgent != null)
            UnEquip(_weaponAgent);

        weaponAgent.View().SetAvatar(HandAnchor);
        _weaponAgent = weaponAgent;

        Combat.SetWeapon(_weaponAgent);
    }

    public void UnEquip(IWeaponAgent itemAgent)
    {
        itemAgent.View().Exit();
    }
}