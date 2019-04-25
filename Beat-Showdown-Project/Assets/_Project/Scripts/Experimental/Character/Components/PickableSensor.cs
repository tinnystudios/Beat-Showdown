using App.Items.Models;
using System.Linq;
using UnityEngine;

namespace Experimental
{
    public class PickableSensor
    {
        private Transform _transform;
        private LayerMask _layerMask;
        private IPickable _lastPickComponent = null;

        public PickableSensor(LayerMask pickableLayer, Transform transform)
        {
            _layerMask = pickableLayer;
            _transform = transform;
        }

        public IPickable FindNearestPickable(Vector3 pos, Vector3 dir)
        {
            var hits = Physics.SphereCastAll(_transform.position, 1, _transform.forward, 0, _layerMask);
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