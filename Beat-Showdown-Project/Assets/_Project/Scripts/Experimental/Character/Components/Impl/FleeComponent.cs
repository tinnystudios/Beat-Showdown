using Experimental;
using UnityEngine;

[RequireComponent(typeof(ITargetProvider))]
public class FleeComponent : MovementBase<ITargetProvider>
{
    public float FleeRange = 5;

    public override void Move()
    {
        var target = Model.Target;

        var dist = Vector3.Distance(transform.position, target.position);
        if (dist <= FleeRange)
        {
            var heading = target.position - transform.position;
            heading.Normalize();
            heading.y = 0;

            transform.position += heading * -MoveSpeed * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, FleeRange);
    }
}