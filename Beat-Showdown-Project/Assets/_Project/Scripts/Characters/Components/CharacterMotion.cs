using App.Characters.Models;
using UnityEngine;

namespace App.Characters.Components
{
    public class CharacterMotion : MonoBehaviour, IBind<Rigidbody>
    {
        [SerializeField] private MotionModel _MotionModel;
        private Rigidbody _rigidBody;

        public void Bind(Rigidbody rigidBody) { _rigidBody = rigidBody; }

        public void Jump()
        {
            _rigidBody.velocity = Vector3.up * _MotionModel.JumpForce;
        }

        public void Move(Vector3 direction)
        {
            if(direction.magnitude > 0.1F)
                transform.rotation = Quaternion.LookRotation(direction);

            transform.position += direction * _MotionModel.MoveSpeed * Time.deltaTime;
        }
    }
}