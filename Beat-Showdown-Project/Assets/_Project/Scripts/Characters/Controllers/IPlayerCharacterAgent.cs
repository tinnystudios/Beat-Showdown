namespace App.Characters.Controllers
{
    public interface IPlayerCharacterAgent
    {
        void UpdateAgent();
        void UseItem(IItemAgent itemAgent);
    }
}