using App.Characters.Models;
using App.Game.UserInput;

namespace App.Characters.Controllers
{
    public class PlayerCharacterAgent : CharacterAgent, IPlayerCharacterAgent
    {
        public CharacterInput Input = new CharacterInput();

        public void ProcessInput()
        {
            if (Input.Jump) Motion.Jump();
            if (Input.Attack) Combat.Attack();

            ProcessPickUp();
            Motion.Move(Input.Move);
        }

        public void ProcessPickUp()
        {
            var pickInterface = Sensory.FindNearestPickable(transform.position, transform.forward);

            if (Input.PickUp && pickInterface != null)
            {
                PickUp(pickInterface.PickItem());
            }
        }

        public void UseItem(IItemAgent itemAgent)
        {
            itemAgent.Use();
        }

        public void BindItem(IItemAgent itemAgent)
        {
            (itemAgent as IBind<CharacterStatus>)?.Bind(Status);
        }
    }
}