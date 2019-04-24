using App.Characters.Components;
using App.Characters.Controllers;
using App.Characters.Models;
using UnityEngine;

public class EnemyAgent : 
    CharacterAgentBase<EnemyView, CharacterStatus, CharacterMotion, EnemyCombat, EnemySensory, CharacterEquipment, EnemyAnimator>,
    IBind<BeatMeterAgent>
{
    public float StopRange = 2;

    public void Bind(BeatMeterAgent beatMeter)
    {
        beatMeter.BPMTool.OnBeat += cont => Move();
    }

    public void Move()
    {
        var player = Sensory.NearestPlayer().transform;

        var dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        var dist = Vector3.Distance(player.position, transform.position);

        if (dist >= StopRange)
            Motion.Move(dirToPlayer * 5);
        else
        {
            Motion.LookAt(dirToPlayer);
            Combat.Attack();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, StopRange);
    }
}
