using UnityEngine;

public static class DataBinderExtensions
{
    public static void Bind<T, TGet>(this MonoBehaviour mono, TGet dependent = null) where T : class, IBind<TGet> where TGet : class
    {
        var dependencies = mono.GetComponentsInChildren<T>(includeInactive: true);

        foreach (var dependency in dependencies)
            dependency.Bind(dependent);
    }
}