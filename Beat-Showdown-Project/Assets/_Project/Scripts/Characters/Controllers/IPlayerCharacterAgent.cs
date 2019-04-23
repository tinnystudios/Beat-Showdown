namespace App.Characters.Controllers
{
    public interface IPlayerCharacterAgent
    {
        void Process();
        void UseItem(IItemAgent itemAgent);
    }
}