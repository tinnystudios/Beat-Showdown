using UnityEngine;

[CreateAssetMenu(menuName = "Game/Ability/Shoot")]
public class ShootAbility : AbilityBase<IWeapon>
{
    public BulletComponent Bullet;
    public float Force = 10;

    public override void Use()
    {
        var weapon = Response.Instance;
        var pivot = weapon.Pivot;

        var bullet = Instantiate(Bullet, pivot.position, pivot.rotation);
        bullet.Init(Force);
    }
}