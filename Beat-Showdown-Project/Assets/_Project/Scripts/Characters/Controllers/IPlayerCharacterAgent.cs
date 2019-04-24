using UnityEngine;

namespace App.Characters.Controllers
{
    public interface IPlayerCharacterAgent
    {
        void Init();
        void UpdateAgent();
        void UseItem(Item item);

        Transform transform { get; }
    }
}