using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterMotion : MonoBehaviour
    {
        public float MoveSpeed = 1;
        public float JumpHeight = 3;

        public Rigidbody Rb;

        public void Jump()
        {
            Rb.velocity = Vector3.up * JumpHeight;
        }

        public void Move(Vector3 direction)
        {
            transform.position += direction * MoveSpeed * Time.deltaTime;
        }
    }
}