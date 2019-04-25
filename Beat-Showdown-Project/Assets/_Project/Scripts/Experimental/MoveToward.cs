using Experimental;
using UnityEngine;

[RequireComponent(typeof(ITargetProvider))]
public class MoveToward : MovementBase<ITargetProvider>
{
    public float StopRange = 5;

    public override void Move()
    {
        var target = Model.Target;

        var dist = Vector3.Distance(transform.position, target.position);
        if (dist <= StopRange)
            return;

        var heading = target.position - transform.position;
        transform.position += heading * MoveSpeed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, StopRange);
    }
}