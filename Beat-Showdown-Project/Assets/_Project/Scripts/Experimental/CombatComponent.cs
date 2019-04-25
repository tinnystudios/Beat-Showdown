using Experimental;
using UnityEngine;

[RequireComponent(typeof(EquipmentComponent))]
public class CombatComponent : CharacterComponentBase<EquipmentComponent, SmartCharacter>, IBind<Animator>
{
    private Animator _animator;

    public override void Activate(SmartCharacter source)
    {
        source.OnAttack += Attack;
    }

    public void Bind(Animator animator)
    {
        _animator = animator;
    }

    private void Attack()
    {
        Model.Weapon.Attack();
        _animator.SetTrigger("Attack");
    }
}