using App.Characters.Components;

public class SwordAgent : EquipmentBaseAgent<SwordModel, SwordView>, IWeaponAgent, IBind<CharacterCombat>
{
    private CharacterCombat _characterCombat = null;

    public SwordAgent(SwordModel model) : base(model)
    {

    }

    public EWeaponType WeaponType => EWeaponType.Sword;

    public void Bind(CharacterCombat characterCombat)
    {
        _characterCombat = characterCombat;
    }

    public override void Use()
    {

    }
}
