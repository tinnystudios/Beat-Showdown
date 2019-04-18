namespace App.Characters.Controllers
{
    public interface ICharacterAgent
    {
        void Init();
        void PickUp(IItemAssetAgent itemAssetAgent);
    }
}