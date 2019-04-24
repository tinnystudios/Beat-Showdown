using App.Characters.Models;

namespace Assets._Project.Scripts.Items
{
    public class PotionAgent : ItemBaseAgent<PotionModel>, IBind<ICharacterStatus>, IConsumableAgent
    {
        private ICharacterStatus _status;

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

        public void Bind(ICharacterStatus status)
        {
            _status = status;
        }
    }
}
