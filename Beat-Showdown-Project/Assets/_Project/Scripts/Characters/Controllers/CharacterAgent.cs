using App.Characters.Components;
using App.Characters.Models;
using App.Characters.Views;

using UnityEngine;

namespace App.Characters.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class CharacterAgent : MonoBehaviour, ICharacterAgent
    {
        public CharacterStatus Status = new CharacterStatus(hp: 5, maxHp: 10);

        [Header("Components")]
        public CharacterView View;
        public CharacterMotion Motion;
        public CharacterCombat Combat;
        public CharacterSensory Sensory;
        public CharacterEquipment Equipment;
        public CharacterAnimator Animator;

        public virtual void Init()
        {
            BindCharacterComponents();
        }

        protected virtual void BindCharacterComponents()
        {
            this.Bind<IBind<ICharacterCombat>, ICharacterCombat>(Combat);
            this.Bind<IBind<ICharacterEquipment>, ICharacterEquipment>(Equipment);
            this.Bind<IBind<ICharacterAnimator>, ICharacterAnimator>(Animator);
            this.Bind<IBind<ICharacterAgent>, ICharacterAgent>(this);
            this.Bind<IBind<Rigidbody>, Rigidbody>(GetComponent<Rigidbody>());
            this.Bind<IBind<ICharacterStatus>, ICharacterStatus>(Status);
        }
    }
}