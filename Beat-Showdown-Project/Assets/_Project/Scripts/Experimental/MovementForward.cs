using Experimental;
using UnityEngine;

public class MovementForward : MovementBase<IMovement>
{
    public override void Move()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}