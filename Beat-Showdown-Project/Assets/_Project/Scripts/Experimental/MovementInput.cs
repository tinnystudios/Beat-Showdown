using UnityEngine;

namespace Experimental
{
    [RequireComponent(typeof(IMovementInput))]
    public class MovementInput : MovementBase<IMovementInput>
    {
        public override void Move()
        {
            transform.position += Model.MoveDir * Time.deltaTime * MoveSpeed;
        }
    }
}