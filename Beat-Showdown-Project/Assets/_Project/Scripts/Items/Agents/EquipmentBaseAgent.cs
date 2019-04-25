using UnityEngine;

/// <summary>
/// Implement this class to create an ItemAvatar
/// </summary>
public abstract class EquipmentBaseAgent<TModel> : ItemBaseAgent<TModel> where TModel : EquipmentBaseModel
{
    protected IItemView _view;

    protected EquipmentBaseAgent(TModel model) : base(model)
    {

    }

    // Instantiate the Scene Item from Model.Prefab
    public override IItemView View()
    {
        if (_view == null)
            _view = GameObject.Instantiate(Model.Prefab);

        return _view;
    }
}