using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterCombatAnimator : CharacterCombat
    {
        public Animator Animator;
        public const string AttackId = "Attack";

        public override void Attack()
        {
            Debug.Log("Set attack trigger");
            Animator.SetTrigger(AttackId);
        }
    }
}