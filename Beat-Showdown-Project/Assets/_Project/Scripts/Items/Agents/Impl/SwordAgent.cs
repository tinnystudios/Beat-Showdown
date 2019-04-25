using App.Characters.Components;

public class SwordAgent : EquipmentBaseAgent<SwordModel>, IWeaponAgent, IBind<CharacterCombat>
{
    private CharacterCombat _characterCombat = null;
    public EWeaponType WeaponType => EWeaponType.Sword;

    public SwordAgent(SwordModel model) : base(model) { }

    public void Bind(CharacterCombat characterCombat)
    {
        _characterCombat = characterCombat;
    }

    public override void Use()
    {

    }
}