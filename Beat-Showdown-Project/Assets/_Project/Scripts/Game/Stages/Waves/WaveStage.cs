using System.Collections;
using App.Characters.Controllers;
using App.Stages.Models;
using UnityEngine;

/// <summary>
/// Run all waves from WaveStageModel
/// </summary>
public class WaveStage : Stage, IBind<PlayerCharacterAgent[]>
{
    private PlayerCharacterAgent[] _players;
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
            foreach (var agent in _players) agent.Process();
            yield return null;
        }
    }

    private void Init()
    {
        foreach (var agent in _players) agent.Init();
    }

    public void Bind(PlayerCharacterAgent[] players)
    {
        _players = players;
    }
}