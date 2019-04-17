using UnityEngine;

namespace App.Game.UserInput
{
    public static class GameInput
    {
        public static Vector2 Joystick => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        public static bool Jump => Input.GetButtonDown("Jump");
        public static bool Attack => Input.GetButtonDown("Fire1");
        public static bool PickUp => Input.GetKeyDown(KeyCode.E);
    }
}