using UnityEngine;

namespace App.Characters.Components
{
    public interface ICharacterAnimator
    {
        Animator Animator { get; }
        void Attack();
        void ChangeWeapon(IWeaponAgent weaponAgent);
    }
}