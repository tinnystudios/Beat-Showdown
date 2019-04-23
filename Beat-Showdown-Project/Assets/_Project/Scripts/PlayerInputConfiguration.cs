using UnityEngine;
using UnityEngine.Experimental.Input;

[CreateAssetMenu(menuName = "Game/Input/PlayerConfiguration")]
public class PlayerInputConfiguration : ScriptableObject
{
    public InputActionReference MoveAction;
    public InputActionReference AttackAction;
    public InputActionReference JumpAction;
}
