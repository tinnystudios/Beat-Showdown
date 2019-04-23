using UnityEngine;

namespace App.Game.UserInput
{
    public class CharacterInput
    {
        public virtual Vector3 Move => new Vector3(GameInput.Joystick.x, 0, GameInput.Joystick.y);
        public virtual bool Jump => GameInput.Jump;
        public virtual bool Attack => GameInput.Attack;
        public virtual bool PickUp => GameInput.PickUp;
    }

    public class Player2Input : CharacterInput
    {
        
    }
}