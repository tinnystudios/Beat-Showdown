using UnityEngine;

namespace App.Game.UserInput
{
    public static class GameInput
    {
        public static Vector2 Joystick => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public static bool Jump => Input.GetButton("Jump");
        public static bool Attack => Input.GetButton("Fire1");
    }
}