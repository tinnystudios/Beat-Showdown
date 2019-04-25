using Experimental;
using UnityEngine;

public class MoveForwardComponent : MovementBase<IMovement>
{
    public override void Move()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}