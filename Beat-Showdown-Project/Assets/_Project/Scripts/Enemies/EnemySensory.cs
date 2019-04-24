using App.Characters.Controllers;
using System.Linq;
using UnityEngine;

public class EnemySensory : MonoBehaviour, ICharacterSensory, IBind<IPlayerCharacterAgent[]>
{
    public float FollowRange = 100;
    public float StopRange = 5;
    public float AttackRange = 3;

    private IPlayerCharacterAgent[] _players;

    public void Bind(IPlayerCharacterAgent[] players)
    {
        _players = players;
    }

    public IPlayerCharacterAgent NearestPlayer()
    {
        var nearestPlayer = _players
            .OrderBy(t => (t.transform.position - transform.position).sqrMagnitude)
            .Take(1)
            .SingleOrDefault();

        return nearestPlayer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, StopRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FollowRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
