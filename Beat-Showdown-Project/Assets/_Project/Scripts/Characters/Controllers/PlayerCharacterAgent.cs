using App.Characters.Components;
using App.Characters.Models;
using App.Characters.Views;

namespace App.Characters.Controllers
{
    /// <summary>
    /// A component based Implementation of CharacterAgent with actions only the player can do
    /// </summary>
    public abstract class PlayerCharacterAgent : 
        CharacterAgentBase<CharacterView, 
        CharacterStatus,
        CharacterMotion,
        CharacterCombat,
        CharacterSensory,
        HumanCharacterEquipment,
        CharacterAnimator>,
        IPlayerCharacterAgent
    {
        public override void Init()
        {
            Status = new CharacterStatus(hp: 5, maxHp: 10);
            MapInputToActions();
            OnPickUp += Equipment.TryEquip;

            base.Init();
        }

        public abstract void MapInputToActions();
        public abstract void UpdateAgent();
    }
}