using UnityEngine;

/// <summary>
/// Bind all necessary to existing MonoBehaviours in the scene
/// </summary>
public class GameDataBinder : MonoBehaviour
{
    public void Bind()
    {
        this.Bind<IBind<BeatMeterAgent>,BeatMeterAgent>();
        this.Bind<IBind<IPlayerCharacter[]>, IPlayerCharacter[]>();
        this.Bind<IBind<IEnemyCharacter[]>, IEnemyCharacter[]>();
    }
}
