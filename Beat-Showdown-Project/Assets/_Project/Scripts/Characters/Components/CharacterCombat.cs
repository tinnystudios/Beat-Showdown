using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterCombat : MonoBehaviour
    {
        public Animator Animator;
        public IWeaponAgent WeaponAgent { get; private set; }

        public void SetWeapon(IWeaponAgent weapon)
        {
            WeaponAgent = weapon;
            SetAnimatorUser();
        }

        public virtual void Attack()
        {
            WeaponAgent?.Use();
            Animator.SetTrigger("Attack");
        }

        public void SetAnimatorUser()
        {
            Animator.SetTrigger($"{WeaponAgent.WeaponType}");
        }
    }
}