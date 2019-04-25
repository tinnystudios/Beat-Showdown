using UnityEngine;

namespace App.Characters.Controllers
{
    public interface IPlayerCharacterAgent
    {
        void Init();
        void UpdateAgent();
        void UseItem(IItemAgent itemAgent);

        Transform transform { get; }
    }
}