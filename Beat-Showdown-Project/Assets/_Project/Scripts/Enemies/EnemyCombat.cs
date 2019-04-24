using App.Characters.Components;
using UnityEngine;

public class EnemyCombat : MonoBehaviour, ICharacterCombat, IBind<ICharacterAnimator>
{
    public ItemAssetBase Weapon;
    public AnimatorOverrideController AnimatorOverride;

    public AvatarAnchorView Anchor;

    private ICharacterAnimator _animator;
    private IItemAgent _weaponAgent;

    public void Bind(ICharacterAnimator animator)
    {
        _animator = animator;
        _animator.Animator.runtimeAnimatorController = AnimatorOverride;

        _weaponAgent = Weapon.CreateAgent();
        _weaponAgent.View().SetAvatar(Anchor);
    }

    public void Attack()
    {
        _weaponAgent.Use();
        _animator.Attack();
    }
}