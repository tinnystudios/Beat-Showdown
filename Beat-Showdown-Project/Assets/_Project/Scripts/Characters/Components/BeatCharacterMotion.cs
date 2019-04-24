using UnityEngine;

namespace App.Characters.Components
{
    public class BeatCharacterMotion : CharacterMotion
    {
        public BeatCondition Condition;
        public bool Pass => Condition != null ? Condition.Pass : true;

        public override void Jump()
        {
            if(Pass)
                base.Jump();
        }

        public override void Move(Vector3 direction)
        {
            if(Pass)
                base.Move(direction);
        }
    }
}