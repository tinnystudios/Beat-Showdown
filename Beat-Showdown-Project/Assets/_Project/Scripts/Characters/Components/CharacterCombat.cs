using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterCombat : MonoBehaviour
    {
        public virtual void Attack()
        {
            Debug.Log("Attack!");
        }
    }
}