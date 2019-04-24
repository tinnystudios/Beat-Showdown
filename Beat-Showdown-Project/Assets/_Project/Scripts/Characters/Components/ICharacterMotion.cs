using UnityEngine;

namespace App.Characters.Components
{
    public interface ICharacterMotion
    {
        void Jump();
        void Move(Vector3 direction);
    }
}