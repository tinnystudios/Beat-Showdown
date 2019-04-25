using UnityEngine;

namespace Experimental
{
    public class AICharacter : SmartCharacter
    {
        private void Update()
        {
            OnMove?.Invoke();
        }
    }
}
