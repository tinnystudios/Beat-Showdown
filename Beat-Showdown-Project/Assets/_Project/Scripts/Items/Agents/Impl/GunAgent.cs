using App.Items.Models;
using UnityEngine;

public class GunAgent : EquipmentBaseAgent<GunModel, GunView>, IWeaponAgent
{
    public GunAgent(GunModel model) : base(model)
    {

    }

    public override void Use()
    {
        var position = View().transform.position;
        var rotation = View().transform.rotation;

        var bullet = GameObject.Instantiate(Model.BulletPrefab, position, rotation);
        bullet.Init(Model.Power);
    }
}
