using App.Characters.Components;
using App.Characters.Controllers;
using App.Characters.Models;
using UnityEngine;

public class EnemyAgent : 
    CharacterAgentBase<EnemyView, CharacterStatus, CharacterMotion, EnemyCombat, EnemySensory, EnemyEquipment, EnemyAnimator>,
    IBind<BeatMeterAgent>
{
    public void Bind(BeatMeterAgent beatMeter)
    {
        beatMeter.BPMTool.OnBeat += cont => Run();
    }

    public void Run()
    {
        var player = Sensory.NearestPlayer().transform;

        var dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        var dist = Vector3.Distance(player.position, transform.position);

        if (dist >= Sensory.StopRange)
            Motion.Move(dirToPlayer);

        if(dist <= Sensory.AttackRange)
        {
            Motion.LookAt(dirToPlayer);
            Combat.Attack();
        }
    }
}
