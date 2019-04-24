using App.Characters.Models;
using UnityEngine;

public interface IItemUser
{
    Transform transform { get; }
    GameObject gameObject { get; }
}

public class MockPlayer : MonoBehaviour, IItemUser
{
    public Item Item;
    public CharacterStatus Status = new CharacterStatus(3, 10);
    public AvatarAnchorView WeaponAnchor;
    public Animator Animator;
    private IWeapon Weapon;
    private void Awake()
    {
        PickUp(Item);
    }

    public void PickUp(Item item)
    {
        ResolveItemDependencies(item);

        var weapon = item as IWeapon;
        if (weapon != null)
        {
            var weaponAnchorTransform = WeaponAnchor.transform;
            var weaponInstance = Instantiate(weapon.WeaponPrefab, weaponAnchorTransform.position, weaponAnchorTransform.rotation);

            weaponInstance.transform.SetParent(weaponAnchorTransform);
            Animator.runtimeAnimatorController = weapon.RuntimeAnimator;
            weapon.Instance = weaponInstance;

            Weapon = weapon;
        }
    }

    public void ResolveItemDependencies(Item item)
    {
        foreach (var ability in item.Abilities)
        {
            (ability as IBind<ICharacterStatus>)?.Bind(Status);
            (ability as IBind<IAvatarAnchor>)?.Bind(WeaponAnchor);

            if(Weapon != null)
                (ability as IBind<IWeapon>)?.Bind(Weapon);
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
            UseItem(Item);

        if (Input.GetKeyUp(KeyCode.F))
        {
            Animator.SetTrigger("Attack");
            Weapon?.Attack();
        }
    }

    public void UseItem(Item item)
    {
        item.Use();
    }
}