using App.Characters.Controllers;
using System.Linq;
using UnityEngine;

public class EnemySensory : MonoBehaviour, ICharacterSensory, IBind<IPlayerCharacterAgent[]>
{
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
}
