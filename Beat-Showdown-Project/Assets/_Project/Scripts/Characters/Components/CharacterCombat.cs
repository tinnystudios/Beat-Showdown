using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterCombat : MonoBehaviour
    {
        // The attack depends on the Item you are holding

        public virtual void Attack()
        {
            Debug.Log("Attack!");
        }
    }
}