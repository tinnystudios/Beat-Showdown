using App.Characters.Controllers;
using UnityEngine;

public class GameDataBinder : MonoBehaviour
{
    public BeatMeterAgent BeatMeterAgent;

    public void Bind()
    {
        var beatMeterAgentDependents = GetComponentsInChildren<IBind<BeatMeterAgent>>(includeInactive: true);
        foreach (var dependent in beatMeterAgentDependents)
        {
            dependent.Bind(BeatMeterAgent);
        }

        var playersDependents = GetComponentsInChildren<IBind<PlayerCharacterAgent[]>>(includeInactive: true);
        var players = GetComponentsInChildren<PlayerCharacterAgent>(includeInactive: true);

        foreach (var playersDependent in playersDependents)
        {
            playersDependent.Bind(players);
        }
    }
}
