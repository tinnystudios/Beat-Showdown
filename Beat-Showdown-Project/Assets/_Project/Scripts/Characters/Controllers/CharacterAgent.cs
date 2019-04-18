using App.Characters.Components;
using App.Characters.Models;
using App.Characters.Views;

using UnityEngine;

namespace App.Characters.Controllers
{
    public class CharacterAgent : MonoBehaviour, ICharacterAgent
    {
        public CharacterStatus Status = null;
        public CharacterView View;

        public Inventory Inventory = new Inventory();

        [Header("Components")]
        public CharacterMotion Motion;
        public CharacterCombat Combat;
        public CharacterSensory Sensory;

        public void Init()
        {
            Status = new CharacterStatus(hp: 5, maxHp: 10);
            View.Init(Status);
        }
    }
}