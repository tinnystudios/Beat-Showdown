using System;
using UnityEngine;
using UnityEngine.Experimental.Input;

[CreateAssetMenu(menuName = "Game/Input/PlayerInputConfig")]
public class PlayerInputConfig : ScriptableObject
{
    public InputActionReference Attack;
    public InputActionReference Move;
    public InputActionReference Jump;
    public InputActionReference PickUp;

    public InputAction AttackAction => Attack.action;
    public InputAction MoveAction => Move.action;
    public InputAction JumpAction => Jump.action;
    public InputAction PickUpAction => PickUp.action;

    public void Init()
    {
        Attack.action.Enable();
        Move.action.Enable();
        Jump.action.Enable();
        PickUp.action.Enable();
    }
}
