using App.Characters.Components;
using App.Characters.Controllers;
using App.Characters.Models;
using UnityEngine;

public class MockPlayer : MonoBehaviour
{
    public CharacterMotion Motion;
    public CharacterSensory Sensory;

    public Item Item;
    public CharacterStatus Status = new CharacterStatus(3, 10);
    public AvatarAnchorView WeaponAnchor;
    public Animator Animator;

    private IWeapon Weapon;

    public void PickUp(Item item)
    {
        var weapon = item as IWeapon;
        if (weapon != null)
        {
            if (Weapon != null)
            {
                Destroy(Weapon.Instance.gameObject);
            }

            var weaponAnchorTransform = WeaponAnchor.transform;
            var weaponInstance = Instantiate(weapon.WeaponPrefab, weaponAnchorTransform.position, weaponAnchorTransform.rotation);

            weaponInstance.transform.SetParent(weaponAnchorTransform);
            Animator.runtimeAnimatorController = weapon.RuntimeAnimator;
            weapon.Instance = weaponInstance;

            Weapon = weapon;
        }

        ResolveItemDependencies(item);
    }

    public void ResolveItemDependencies(Item item)
    {
        foreach (var ability in item.Abilities)
        {
            (ability as IBind<ICharacterStatus>)?.Bind(Status);
            (ability as IBind<IAvatarAnchor>)?.Bind(WeaponAnchor);

            if(Weapon != null)
                (ability as IBind<IShootLocation>)?.Bind(Weapon.Instance.Pivot);
        }
    }

    public void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var dir = new Vector3(x, 0, 0);
        Motion.Move(dir);

        var nearestPickable = Sensory.FindNearestPickable(transform.position, transform.forward);

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (nearestPickable != null)
            {
                PickUp(nearestPickable.GetItem());
            }
        }

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