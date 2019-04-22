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

    public class BeatGameInput : CharacterInput
    {
        public override Vector3 Move
        {
            get
            {
                var x = 0.0F;
                var y = 0.0F;

                if (Input.GetKeyDown(KeyCode.RightArrow))
                    x = 1;

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    x = -1;

                if (Input.GetKeyDown(KeyCode.UpArrow))
                    y = 1;

                if (Input.GetKeyDown(KeyCode.DownArrow))
                    y = -1;

                return new Vector3(x, 0, y);
            }
        }
    }
}