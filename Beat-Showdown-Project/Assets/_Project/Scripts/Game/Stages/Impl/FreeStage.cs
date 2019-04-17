using System.Collections;
using App.Characters.Controllers;
using UnityEngine;

public class FreeStage : Stage
{
    public CharacterAgent[] Players;

    public override Coroutine Run()
    {
        IsRunning = true;
        return StartCoroutine(_Run());
    }

    private IEnumerator _Run()
    {
        foreach (var agent in Players)
        {
            agent.Init();
        }

        while (IsRunning)
        {
            foreach (var agent in Players)
            {
                agent.ProcessInput();
            }

            yield return null;
        }
    }
}