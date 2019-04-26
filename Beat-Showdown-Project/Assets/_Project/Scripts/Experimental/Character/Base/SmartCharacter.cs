using App.Characters.Models;
using System;
using UnityEngine;

namespace Experimental
{
    public abstract class SmartCharacter : CharacterBase, IMovement
    {
        public CharacterStatus Status = new CharacterStatus(hp: 5, maxHp: 10);

        public Action OnMove { get; set; }
        public Action OnJump { get; set; }
        public Action OnAttack { get; set; }

        public Action OnPickUp { get; set; }
        public Action OnUpdateComponents { get; set; }

        protected virtual void Awake()
        {
            ResolveDependencies();
        }

        protected virtual void ResolveDependencies()
        {
            foreach (var c in GetComponentsInChildren<IObserver<SmartCharacter>>())
                c.Register(this);

            this.Bind<IBind<ITargetProvider>, ITargetProvider>();
            this.Bind<IBind<IMovement>, IMovement>(this);
            this.Bind<IBind<Rigidbody>, Rigidbody>();
            this.Bind<IBind<InventoryComponent>, InventoryComponent>();
            this.Bind<IBind<IWeaponAvatar>, IWeaponAvatar>();
            this.Bind<IBind<EquipmentComponent>, EquipmentComponent>();
            this.Bind<IBind<Animator>, Animator>();
            this.Bind<IBind<ICharacterStatus>, ICharacterStatus>(Status);
        }

        public virtual void BindItemOnPickUp(Item item)
        {
            BindAbilities<ICharacterStatus>(item, Status);
        }

        public virtual void BindItemOnEquip(Item item)
        {
            var weapon = item as IWeapon;
            if (weapon != null)
            {
                BindAbilities<IShootLocation>(item, weapon.Instance.Pivot);
            }
        }

        protected void BindAbilities<T>(Item item, T source) where T : class
        {
            foreach (var ability in item.Abilities)
            {
                (ability as IBind<T>)?.Bind(source);
            }
        }
    }
}