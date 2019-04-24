using App.Characters.Controllers;
using System.Linq;
using UnityEngine;

/// <summary>
/// Bind all necessary to existing MonoBehaviours in the scene
/// </summary>
public class GameDataBinder : MonoBehaviour
{
    public BeatMeterAgent BeatMeterAgent;

    public void Bind()
    {
        var players = GetComponentsInChildren<IPlayerCharacterAgent>();
        var enemies = GetComponentsInChildren<EnemyAgent>(includeInactive: true);

        this.Bind<IBind<BeatMeterAgent>,BeatMeterAgent>(BeatMeterAgent);
        this.Bind<IBind<IPlayerCharacterAgent[]>, IPlayerCharacterAgent[]>(players);
        this.Bind<IBind<EnemyAgent[]>, EnemyAgent[]>(enemies);
    }
}
