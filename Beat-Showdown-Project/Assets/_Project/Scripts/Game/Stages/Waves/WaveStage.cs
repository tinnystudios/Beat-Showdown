using System.Collections;
using App.Characters.Controllers;
using App.Stages.Models;
using UnityEngine;

/// <summary>
/// Run all waves from WaveStageModel
/// </summary>
public class WaveStage : Stage, IBind<IPlayerCharacterAgent[]>, IBind<EnemyAgent[]>
{
    private IPlayerCharacterAgent[] _players;
    private EnemyAgent[] _enemyAgents;

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
            foreach (var agent in _players) agent.UpdateAgent();
            yield return null;
        }
    }

    private void Init()
    {
        foreach (var agent in _players) agent.Init();
        foreach (var agent in _enemyAgents) agent.Init();
    }

    public void Bind(IPlayerCharacterAgent[] players) { _players = players; }
    public void Bind(EnemyAgent[] agents) { _enemyAgents = agents; }
}