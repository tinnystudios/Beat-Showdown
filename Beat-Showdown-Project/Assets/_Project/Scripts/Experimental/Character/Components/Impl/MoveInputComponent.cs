using UnityEngine;

namespace Experimental
{
    [RequireComponent(typeof(IMovementInput))]
    public class MoveInputComponent : MovementBase<IMovementInput>
    {
        public override void Move()
        {
            transform.position += Model.MoveDir * Time.deltaTime * MoveSpeed;
        }
    }
}