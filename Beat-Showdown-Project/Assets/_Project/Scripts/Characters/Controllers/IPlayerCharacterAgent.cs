namespace App.Characters.Controllers
{
    public interface IPlayerCharacterAgent
    {
        void ProcessInput();
        void ProcessPickUp();
        void UseItem(IItemAgent itemAgent);
        void PickUp(IItemAssetAgent itemAssetAgent);
    }
}