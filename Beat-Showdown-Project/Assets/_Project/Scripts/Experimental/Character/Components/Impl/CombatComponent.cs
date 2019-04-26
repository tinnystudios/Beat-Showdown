using Experimental;
using UnityEngine;

[RequireComponent(typeof(EquipmentComponent))]
public class CombatComponent : CharacterObserverBase<EquipmentComponent, SmartCharacter>, IBind<Animator>
{
    private Animator _animator;

    public override void Register(SmartCharacter source)
    {
        source.OnAttack += Attack;
    }

    public virtual void Bind(Animator animator)
    {
        _animator = animator;
    }

    public virtual void Attack()
    {
        Model.Weapon?.Attack();
        _animator.SetTrigger("Attack");
    }
}