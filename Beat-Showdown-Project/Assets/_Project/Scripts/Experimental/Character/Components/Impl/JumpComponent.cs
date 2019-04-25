using Experimental;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpComponent : CharacterComponentBase<Rigidbody, SmartCharacter>
{
    public float Velocity = 10;

    public override void Activate(SmartCharacter smartCharacter)
    {
        smartCharacter.OnJump += Jump;
    }

    private void Jump()
    {
        Model.velocity = Vector3.up * Velocity;
    }
}