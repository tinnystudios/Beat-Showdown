using App.Characters.Components;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour, ICharacterAnimator
{
    [SerializeField] private Animator _Animator;
    public Animator Animator => _Animator;

    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }
}
