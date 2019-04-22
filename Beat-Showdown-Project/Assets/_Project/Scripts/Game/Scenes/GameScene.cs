using System.Collections;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public Stage Stage;
    public GameDataBinder GameBinder;

    private IEnumerator Start()
    {
        GameBinder.Bind();
        yield return OpeningIntro();
        yield return Stage.Run();
        yield return Ending();
    }

    private IEnumerator OpeningIntro()
    {
        yield break;
    }

    private IEnumerator Ending()
    {
        yield break;
    }
}