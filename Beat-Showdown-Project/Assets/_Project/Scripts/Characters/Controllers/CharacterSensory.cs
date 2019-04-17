using System.Linq;
using App.Items.Models;
using UnityEngine;

namespace App.Characters.Controllers
{
    public class CharacterSensory : MonoBehaviour
    {
        public LayerMask SensorLayer;
        private IPickable _lastPickComponent = null;

        public IPickable FindNearestPickable(Vector3 pos, Vector3 dir)
        {
            var hits = Physics.SphereCastAll(transform.position, 1, transform.forward, 0, SensorLayer);
            var pickable = hits
                .Select(x => x.transform.GetComponentInParent<IPickable>())
                .OrderBy(t => (t.transform.position - pos).sqrMagnitude)
                .Take(1)
                .SingleOrDefault();

            if (pickable != null && pickable != _lastPickComponent)
            {
                _lastPickComponent?.Deselect();
                _lastPickComponent = pickable;
            }

            if (pickable == null)
            {
                _lastPickComponent?.Deselect();
            }
            else
            {
                pickable.Select();
                return pickable;
            }

            return null;
        }
    }
}