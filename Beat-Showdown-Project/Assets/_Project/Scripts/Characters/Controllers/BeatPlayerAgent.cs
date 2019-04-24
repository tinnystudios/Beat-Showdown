using App.Characters.Controllers;
using App.Items.Models;
using System;
using UnityEngine;

/// <summary>
/// A Game Implementation of PlayerCharacterAgent
/// </summary>
public class BeatPlayerAgent : PlayerCharacterAgent, IBind<BeatMeterAgent>
{
    [Header("Beat Condition")]
    public BeatCondition BeatCondition;
    public BeatConditionConstraints BeatConstraints;

    [Header("Configs")]
    public PlayerInputConfig InputConfig;
    public IPickable ClosestPickable { get; private set; }

    public void Bind(BeatMeterAgent beatMeterAgent) { BeatCondition?.Bind(beatMeterAgent); }

    public override void MapInputToActions()
    {
        InputConfig.Init();
        InputConfig.MoveAction.performed += context => Move(context.ReadValue<Vector2>());
        InputConfig.AttackAction.performed += context => Attack();
        InputConfig.JumpAction.performed += context => Jump();
        InputConfig.PickUpAction.performed += context => PickUp();
    }

    public bool Pass => BeatCondition != null ? BeatCondition.Pass : true;

    public void Move(Vector2 delta)
    {
        if (BeatConstraints.Move && !Pass) return;

        var dir = new Vector3(delta.x, 0, delta.y);
        Motion.Move(dir);
    }

    public void Attack()
    {
        if (BeatConstraints.Attack && !Pass) return;
        Combat.Attack();
    }

    public void Jump()
    {
        if (BeatConstraints.Jump && !Pass) return;
        Motion.Jump();
    }

    public void PickUp()
    {
        if (BeatConstraints.PickUp && !Pass) return;

        if (ClosestPickable != null)
            PickUp(ClosestPickable.PickItem());
    }

    public override void UpdateAgent()
    {
        ClosestPickable = Sensory.FindNearestPickable(transform.position, transform.forward);
    }
}

[Serializable]
public class BeatConditionConstraints
{
    public bool Move;
    public bool Jump;
    public bool Attack;
    public bool PickUp;
}