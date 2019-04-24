using App.Characters.Components;
using UnityEngine;

public class EnemyCombat : MonoBehaviour, ICharacterCombat, IBind<ICharacterAnimator>, IBind<ICharacterEquipment>
{
    public Item Weapon;
    public AnimatorOverrideController AnimatorOverride;

    public AvatarAnchorView Anchor;

    private ICharacterAnimator _animator;
    private ICharacterEquipment _equipment;

    public void Bind(ICharacterAnimator animator)
    {
        _animator = animator;
        _animator.Animator.runtimeAnimatorController = AnimatorOverride;

        _equipment.TryEquip(Weapon);
    }

    public void Attack()
    {
        _equipment.WeaponAgent.Attack();
        _animator.Attack();
    }

    public void Bind(ICharacterEquipment equipment)
    {
        _equipment = equipment;
    }
}