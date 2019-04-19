using UnityEngine;

public abstract class EquipmentAgent<TModel, TView> : ItemAgentBase<TModel> where TModel : EquipmentModel<TView> where TView : ItemBaseView
{
    protected IItemView _view;

    public EquipmentAgent(TModel model) : base(model)
    {

    }

    public override IItemView View()
    {
        if (_view == null)
            _view = GameObject.Instantiate(Model.Prefab);

        return _view;
    }
}
