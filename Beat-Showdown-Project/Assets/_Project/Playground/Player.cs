using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputConfig InputConfig;

    private void Awake()
    {
        InputConfig.Attack.action.Enable();
        InputConfig.Attack.action.performed += cont => Debug.Log("Attack");

        InputConfig.Move.action.Enable();
        InputConfig.Move.action.performed += OnMove;
    }

    private void OnDisable()
    {
        InputConfig.Attack.action.Disable();
        InputConfig.Move.action.Disable();
    }

    private void OnMove(UnityEngine.Experimental.Input.InputAction.CallbackContext context)
    {
        var delta = context.ReadValue<Vector2>();
        transform.position += new Vector3(delta.x, 0, delta.y) * Time.deltaTime * 5;
    }
}