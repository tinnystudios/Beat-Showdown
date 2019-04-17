using System.Collections;
using App.Characters.Controllers;
using App.Stages.Models;
using UnityEngine;

/// <summary>
/// Run all waves from WaveStageModel
/// </summary>
public class WaveStage : Stage
{
    public CharacterAgent[] Players;
    public WaveStageModel Model;

    public override Coroutine Run()
    {
        IsRunning = true;
        return StartCoroutine(_Run());
    }

    private IEnumerator _Run()
    {
        Init();

        while (IsRunning)
        {
            foreach (var agent in Players) agent.ProcessInput();
            yield return null;
        }
    }

    private void Init()
    {
        foreach (var agent in Players) agent.Init();
    }
}