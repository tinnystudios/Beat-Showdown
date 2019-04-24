using UnityEngine;

[CreateAssetMenu(menuName = "Game/Ability/Shoot")]
public class ShootAbility : AbilityBase<IShootLocation>
{
    public BulletComponent Bullet;
    public float Force = 10;

    public override void Use()
    {
        var shootLocation = Response;
        var pivot = shootLocation.transform;

        var bullet = Instantiate(Bullet, pivot.position, pivot.rotation);
        bullet.Init(Force);
    }
}