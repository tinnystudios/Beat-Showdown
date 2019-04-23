using UnityEngine;
using UnityEngine.Experimental.Input;

[CreateAssetMenu(menuName = "Game/Input/PlayerInputConfig")]
public class PlayerInputConfig : ScriptableObject
{
    public InputActionReference Attack;
    public InputActionReference Move;
    public InputActionReference Jump;
    public InputActionReference PickUp;
}
