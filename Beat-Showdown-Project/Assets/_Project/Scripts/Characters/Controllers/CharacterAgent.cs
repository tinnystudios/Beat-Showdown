using App.Characters.Models;
using App.Characters.Views;

using UnityEngine;

namespace App.Characters.Controllers
{
    public abstract class CharacterAgent : MonoBehaviour, ICharacterAgent
    {
        public CharacterStatus Status = new CharacterStatus(hp: 5, maxHp: 10);
        public CharacterView View;

        public abstract void Init();
    }
}