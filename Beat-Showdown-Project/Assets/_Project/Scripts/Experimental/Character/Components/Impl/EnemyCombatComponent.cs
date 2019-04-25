using System.Collections;
using UnityEngine;

public class EnemyCombatComponent : CombatComponent, IBind<ITargetProvider>
{
    public Weapon Weapon;

    public float CoolDownDuration = 1;
    public float AttackRange = 4;

    private bool _isCoolingDown = false;
    private ITargetProvider _targetProvider;

    public void Bind(ITargetProvider targetProvider) { _targetProvider = targetProvider; }

    public override void Bind(Animator animator)
    {
        base.Bind(animator);
        Model.TryEquip(Weapon.Clone());
    }

    public override void Attack()
    {
        var distance = Vector3.Distance(transform.position, _targetProvider.Target.position);

        if (distance <= AttackRange && !_isCoolingDown)
        {
            base.Attack();
            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator CoolDown()
    {
        _isCoolingDown = true;
        yield return new WaitForSeconds(CoolDownDuration);
        _isCoolingDown = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}