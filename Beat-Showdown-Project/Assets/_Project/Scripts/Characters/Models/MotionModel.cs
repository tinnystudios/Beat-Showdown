using UnityEngine;

namespace App.Characters.Models
{
    [CreateAssetMenu(menuName = "Game/Character/Motion")]
    public class MotionModel : ScriptableObject
    {
        public float MoveSpeed = 10;
        public float JumpForce = 5;
    }
}