using App.Characters.Controllers;
using App.Items.Models;
using UnityEngine;

/// <summary>
/// A Game Implementation of PlayerCharacterAgent
/// </summary>
public class BeatPlayerAgent : PlayerCharacterAgent, IBind<BeatMeterAgent>
{
    [Header("Configs")]
    public BeatCondition BeatCondition;
    public PlayerInputConfig InputConfig;

    public IPickable ClosestPickable { get; private set; }

    public void Bind(BeatMeterAgent beatMeterAgent) { BeatCondition.Bind(beatMeterAgent); }

    public override void MapInputToActions()
    {
        InputConfig.Init();
        InputConfig.MoveAction.performed += context => Move(context.ReadValue<Vector2>());
        InputConfig.AttackAction.performed += context => Attack();
        InputConfig.JumpAction.performed += context => Jump();
        InputConfig.PickUpAction.performed += context => PickUp();
    }

    public void Move(Vector2 delta)
    {
        if (!BeatCondition.Pass) return;
        var dir = new Vector3(delta.x, 0, delta.y);
        Motion.Move(dir);
    }

    public void Attack()
    {
        if (!BeatCondition.Pass) return;
        Combat.Attack();
    }

    public void Jump()
    {
        if (!BeatCondition.Pass) return;
        Motion.Jump();
    }

    public void PickUp()
    {
        if (!BeatCondition.Pass) return;

        if (ClosestPickable != null)
            PickUp(ClosestPickable.PickItem());
    }

    public override void UpdateAgent()
    {
        ClosestPickable = Sensory.FindNearestPickable(transform.position, transform.forward);
    }
}