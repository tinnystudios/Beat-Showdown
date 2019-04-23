using UnityEngine;
using UnityEngine.Experimental.Input;

public class Player : MonoBehaviour
{
    public InputActionReference Attack;

    private void Awake()
    {
        Attack.action.Enable();
        Attack.action.performed += cont => Debug.Log("Attack");
    }
}
