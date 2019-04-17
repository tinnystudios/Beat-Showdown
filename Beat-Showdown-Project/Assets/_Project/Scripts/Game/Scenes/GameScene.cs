using System.Collections;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public Stage Stage;

    // This is where Flow would be useful?
    private IEnumerator Start()
    {
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