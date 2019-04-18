using App.Characters.Models;
using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterMotion : MonoBehaviour
    {
        public MotionModel MotionModel;
        public Rigidbody Rb;

        public void Jump()
        {
            Rb.velocity = Vector3.up * MotionModel.JumpForce;
        }

        public void Move(Vector3 direction)
        {
            if(direction.magnitude > 0.1F)
                transform.rotation = Quaternion.LookRotation(direction);

            transform.position += direction * MotionModel.MoveSpeed * Time.deltaTime;
        }
    }
}