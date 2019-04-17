using App.Characters.Models;

namespace Assets._Project.Scripts.Items
{
    public class PotionAgent : ItemAgentBase<PotionModel>, IBind<CharacterStatus>
    {
        private CharacterStatus _status;

        public PotionAgent(PotionModel model) : base(model)
        {

        }

        public override void Use()
        {
            _status.AddHp(Model.Hp);
        }

        public void Bind(CharacterStatus status)
        {
            _status = status;
        }
    }
}