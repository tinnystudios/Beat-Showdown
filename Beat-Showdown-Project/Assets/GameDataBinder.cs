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
        var players = GetComponentsInChildren<IPlayerCharacterAgent>(includeInactive: true);

        this.Bind<IBind<BeatMeterAgent>,BeatMeterAgent>(BeatMeterAgent);
        this.Bind<IBind<IPlayerCharacterAgent[]>, IPlayerCharacterAgent[]>(players);
    }
}
