using App.Characters.Components;
using App.Characters.Models;
using App.Characters.Views;
using App.Items.Models;
using System;
using UnityEngine;

namespace App.Characters.Controllers
{
    /// <summary>
    /// A base for any characters cabable of Motion, Combat, Sensory, Equipment and Animator
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class CharacterAgentBase<TView, TStatus, TMotion, TCombat, TSensory, TEquipment, TAnimator> : MonoBehaviour, 
        ICharacterAgent, 
        IPickableAgent
        where TView : ICharacterView
        where TStatus : ICharacterStatus
        where TMotion : ICharacterMotion
        where TCombat : ICharacterCombat
        where TSensory : ICharacterSensory
        where TEquipment : ICharacterEquipment
        where TAnimator : ICharacterAnimator
    {
        public TView View;
        public TStatus Status;

        [Header("Components")]
        public TMotion Motion;
        public TCombat Combat;
        public TSensory Sensory;
        public TEquipment Equipment;
        public TAnimator Animator;

        public Action<IItemAgent> OnPickUp { get; set; }

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

        public virtual void PickUp(IItemAssetAgent itemAssetAgent)
        {
            var itemAgent = itemAssetAgent.CreateAgent();

            BindItem((itemAgent));
            GetInterface<IConsumableAgent>(itemAgent)?.Use();

            OnPickUp?.Invoke(itemAgent);
        }

        public virtual void UseItem(IItemAgent itemAgent)
        {
            itemAgent.Use();
        }

        public virtual void BindItem(IItemAgent itemAgent)
        {
            GetInterface<IBind<ICharacterStatus>>(itemAgent)?.Bind(Status);
            GetInterface<IBind<ICharacterCombat>>(itemAgent)?.Bind(Combat);
        }

        public T GetInterface<T>(IItemAgent itemAgent) where T : class
        {
            return itemAgent as T;
        }
    }
}