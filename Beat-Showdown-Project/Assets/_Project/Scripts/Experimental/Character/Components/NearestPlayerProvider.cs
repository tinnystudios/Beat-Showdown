using Experimental;
using System.Linq;
using UnityEngine;

public class NearestPlayerProvider : MonoBehaviour, ITargetProvider
{
    public Transform Target
    {
        get
        {
            return 
                FindObjectsOfType<PlayerCharacter>()
                .Select(x => x.transform)
                .OrderBy(t => (t.position - transform.position).sqrMagnitude)
                .Take(1)
                .SingleOrDefault();
        }
    }
}