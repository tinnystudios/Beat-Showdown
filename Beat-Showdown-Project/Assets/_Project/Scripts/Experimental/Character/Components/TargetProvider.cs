using UnityEngine;

public class TargetProvider : MonoBehaviour, ITargetProvider
{
    [SerializeField] private Transform _Target;
    public Transform Target => _Target;
}
