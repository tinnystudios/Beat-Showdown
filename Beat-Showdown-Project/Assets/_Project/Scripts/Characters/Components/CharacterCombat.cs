using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterCombat : MonoBehaviour, ICharacterCombat, IBind<ICharacterEquipment>, IBind<ICharacterAnimator>
    {
        private ICharacterEquipment _equipment;
        private ICharacterAnimator _characterAnimator;

        public void Bind(ICharacterEquipment equipment) { _equipment = equipment; }
        public void Bind(ICharacterAnimator animator) { _characterAnimator = animator; }

        public virtual void Attack()
        {
            _equipment.WeaponAgent?.Use();
            _characterAnimator.Attack();
        }
    }
}