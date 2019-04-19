using App.Characters.Models;

namespace Assets._Project.Scripts.Items
{
    public class PotionAgent : ItemAgentBase<PotionModel>, IBind<CharacterStatus>, IConsumableAgent
    {
        private CharacterStatus _status;

        public PotionAgent(PotionModel model) : base(model)
        {

        }

        public override IItemView View()
        {
            // Currently the potion does not have a view
            return null;
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
