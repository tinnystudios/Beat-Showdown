using UnityEngine;

namespace App.Game.UserInput
{
    public class CharacterInput
    {
        public Vector3 Move => new Vector3(GameInput.Joystick.x, 0, GameInput.Joystick.y);
        public bool Jump => GameInput.Jump;
        public bool Attack => GameInput.Attack;
        public bool PickUp => GameInput.PickUp;
    }
}