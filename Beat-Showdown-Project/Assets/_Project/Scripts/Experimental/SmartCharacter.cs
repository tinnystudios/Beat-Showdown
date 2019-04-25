using System;
using UnityEngine;

namespace Experimental
{
    public abstract class SmartCharacter : CharacterBase, IMovement
    {
        public Action OnMove { get; set; }
        public Action OnJump { get; set; }
        public Action OnAttack { get; set; }

        public Action OnPickUp { get; set; }

        protected virtual void Awake()
        {
            ResolveDependencies();
        }

        protected virtual void ResolveDependencies()
        {
            foreach (var c in GetComponentsInChildren<ICharacterComponent<SmartCharacter>>())
                c.Activate(this);

            this.Bind<IBind<ITargetProvider>, ITargetProvider>();
            this.Bind<IBind<IMovement>, IMovement>(this);
            this.Bind<IBind<Rigidbody>, Rigidbody>();
            this.Bind<IBind<InventoryComponent>, InventoryComponent>();
            this.Bind<IBind<IWeaponAvatar>, IWeaponAvatar>();
            this.Bind<IBind<EquipmentComponent>, EquipmentComponent>();
            this.Bind<IBind<Animator>, Animator>();
        }
    }
}