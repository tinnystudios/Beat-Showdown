using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterCombat : MonoBehaviour
    {
        public IItemAgent WeaponAgent { get; private set; }

        public void SetWeapon(IItemAgent weapon)
        {
            WeaponAgent = weapon;
        }

        public virtual void Attack()
        {
            WeaponAgent?.Use();
        }
    }
}