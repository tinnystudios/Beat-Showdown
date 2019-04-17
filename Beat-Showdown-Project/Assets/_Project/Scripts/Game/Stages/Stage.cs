using UnityEngine;

public abstract class Stage : MonoBehaviour
{
    protected bool IsRunning;
    public abstract Coroutine Run();
}