using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterCombat : MonoBehaviour
    {
        public Animator Animator;

        public AnimatorOverrideController GunnerOverrideController;
        public AnimatorOverrideController SwordsmanOverrideController;

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
            // #TODO The Model of a weapon type would contain its AnimatorOverrideController
            switch (WeaponAgent.WeaponType)
            {
                case EWeaponType.Gun:
                    Animator.runtimeAnimatorController = GunnerOverrideController;
                    break;

                case EWeaponType.Sword:
                    Animator.runtimeAnimatorController = SwordsmanOverrideController;
                    break;
            }
        }
    }
}