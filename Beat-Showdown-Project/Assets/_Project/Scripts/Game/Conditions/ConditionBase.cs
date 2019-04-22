using UnityEngine;

public abstract class ConditionBase<T> : ScriptableObject, IBind<T> where T : class
{
    public T Value;

    public void Bind(T dependency)
    {
        Value = dependency;
    }

    public abstract bool Pass { get; }
}
