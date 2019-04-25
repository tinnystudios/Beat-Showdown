using Experimental;
using UnityEngine;

[RequireComponent(typeof(ITargetProvider))]
public class MoveTowardComponent : MovementBase<ITargetProvider>
{
    public float StopRange = 5;
    public float FollowRange = 5;

    public override void Move()
    {
        var target = Model.Target;
        transform.LookAt(target.position);

        var dist = Vector3.Distance(transform.position, target.position);

        if (dist <= StopRange)
            return;

        if (dist <= FollowRange)
        {
            var heading = target.position - transform.position;
            heading.Normalize();
            heading.y = 0;

            transform.position += heading * MoveSpeed * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, StopRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, FollowRange);
    }
}