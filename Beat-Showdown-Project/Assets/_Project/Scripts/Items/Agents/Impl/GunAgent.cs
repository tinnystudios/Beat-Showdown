using App.Items.Models;
using UnityEngine;

public class GunAgent : ItemAgentBase<GunModel>, IWeaponAgent
{
    private GunView _view;

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

    // #TODO Create an EquipmentAgent that generates views with the model
    public override IItemView View()
    {
        if(_view == null)
            _view = GameObject.Instantiate(Model.Prefab);

        return _view;
    }
}

public interface IWeaponAgent
{

}