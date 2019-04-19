using UnityEngine;

public abstract class EquipmentBaseAgent<TModel, TView> : ItemBaseAgent<TModel> where TModel : EquipmentBaseModel<TView> where TView : ItemBaseView
{
    protected IItemView _view;

    public EquipmentBaseAgent(TModel model) : base(model)
    {

    }

    public override IItemView View()
    {
        if (_view == null)
            _view = GameObject.Instantiate(Model.Prefab);

        return _view;
    }
}
