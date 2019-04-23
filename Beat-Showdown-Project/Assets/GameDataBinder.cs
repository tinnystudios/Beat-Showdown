using App.Characters.Controllers;
using UnityEngine;

public class GameDataBinder : MonoBehaviour
{
    public BeatMeterAgent BeatMeterAgent;

    public void Bind()
    {
        var players = GetComponentsInChildren<PlayerCharacterAgent>(includeInactive: true);

        Bind<IBind<BeatMeterAgent>,BeatMeterAgent>(BeatMeterAgent);
        Bind<IBind<PlayerCharacterAgent[]>, PlayerCharacterAgent[]>(players);
    }

    public void Bind<T, TGet>(TGet dependent = null) where T : class, IBind<TGet> where TGet : class 
    {
        var dependencies = GetComponentsInChildren<T>(includeInactive: true);

        foreach (var dependency in dependencies)
            dependency.Bind(dependent);
    }
}