using System.Collections;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public Stage Stage;

    private IEnumerator Start()
    {
        yield return OpeningIntro();
        yield return Stage.Run();
    }

    private IEnumerator OpeningIntro()
    {
        yield break;
    }
}
