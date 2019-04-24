using UnityEngine;

public abstract class AbilityBase : ScriptableObject
{
    public abstract void Use();
}

public abstract class AbilityBase<T> : AbilityBase, IBind<T> where T : class
{
    public T Response;

    public void Bind(T dependent)
    {
        Response = dependent;
    }
}