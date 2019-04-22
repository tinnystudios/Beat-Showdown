using UnityEngine;

public abstract class ConditionBase<T> : ConditionBase, IBind<T> where T : class
{
    public T Value;

    public void Bind(T dependency)
    {
        Value = dependency;
    }
}

public abstract class ConditionBase : ScriptableObject
{
    public abstract bool Pass { get; }
}