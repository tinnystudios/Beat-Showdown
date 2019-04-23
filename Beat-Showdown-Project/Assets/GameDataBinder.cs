using App.Characters.Controllers;
using UnityEngine;

/// <summary>
/// Bind all necessary to existing MonoBehaviours in the scene
/// </summary>
public class GameDataBinder : MonoBehaviour
{
    public BeatMeterAgent BeatMeterAgent;

    public void Bind()
    {
        var players = GetComponentsInChildren<PlayerCharacterAgent>(includeInactive: true);

        this.Bind<IBind<BeatMeterAgent>,BeatMeterAgent>(BeatMeterAgent);
        this.Bind<IBind<PlayerCharacterAgent[]>, PlayerCharacterAgent[]>(players);
    }
}

public static class DataBinderExtensions
{
    public static void Bind<T, TGet>(this MonoBehaviour mono, TGet dependent = null) where T : class, IBind<TGet> where TGet : class
    {
        var dependencies = mono.GetComponentsInChildren<T>(includeInactive: true);

        foreach (var dependency in dependencies)
            dependency.Bind(dependent);
    }
}