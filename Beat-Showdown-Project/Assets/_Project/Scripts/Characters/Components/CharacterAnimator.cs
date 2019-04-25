using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterAnimator : MonoBehaviour, ICharacterAnimator, IBind<ICharacterEquipment>
    {
        private ICharacterEquipment _equipment;

        [SerializeField] private Animator _Animator;
        [SerializeField] private AnimatorOverrideController GunnerOverrideController;
        [SerializeField] private AnimatorOverrideController SwordsmanOverrideController;

        public Animator Animator => _Animator;

        public void Bind(ICharacterEquipment equipment)
        {
            _equipment = equipment;
            _equipment.OnEquip += ChangeWeapon;
        }

        public void Attack()
        {
            Animator.SetTrigger("Attack");
        }

        public void ChangeWeapon(IWeaponAgent weapon)
        {
            // #TODO The Model of a weapon type would contain its AnimatorOverrideController
            switch (weapon.WeaponType)
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