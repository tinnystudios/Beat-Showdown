## Items

### Breakdown:

Items are structured using MVC with an addition of Scriptable Objects refered to as Asset.

**Agent:** Actions, such as firing a bullet.

**Model:** Containing the data, such as the bullet to fire and the force

**Asset:** A Scriptable Object containing the Model and creates an Agent with the correct model. Can be configure in the editor.

### Creating a brand new item
1. Create an Agent

```
public class PotionAgent : ItemBaseAgent<PotionModel>
{
	public override void Use()
	{
		Model.Status.AddHp(Model.Value);
	}
}
```

2. Create a Model

```
[System.Serializble]
public class PotionModel : IBind<ICharacterStatus>
{
	public float Value = 5;
	
	// This gets injected by the Character that picks it up
	public ICharacterStatus Status;
	
	public void Bind(ICharacterStatus status)
	{ 
		Status = status;
	}
}
```

3. Create an Asset implementing ItemAssetBase<TModel> where TModel is your PotionModel. This will connect the Agent and Model together.

```
[CreateAssetMenu]
public class PotionAsset : ItemAssetBase<PotionModel>
{
    public override IItemAgent CreateAgent()
    {
        return new PotionAgent(Model);
    }
}
``` 

4. Right click in the Project view, `Create > PotionAsset` and configure it. You're Done!

### Creating a new weapon
Creating a new weapon is slightly different as there are already base classes for it. You can still use the system above to create your own.

1. Create an Agent implementing IItemAgent<TModel> where TModel is the Model relating to your Agent

```
public class GunAgent : EquipmentBaseAgent<GunModel>, IWeaponAgent
{
	public override void Use()
	{
		var bullet = Instantiate(Model.Bullet);
		bullet.Fire(Model.Power);
	}
}
```

2. Create a Model implementing EquipmentBaseModel and IWeaponModel

```
[System.Serializble]
public class GunModel : EquipmentBaseModel, IWeaponModel
{
	public BulletComponent Bullet;
	public float Power = 10;
}
```

The View for the items do not need to be created, however to take advantage of Scriptable Objects in Unity
we do have 1 more major step.

3. Create a Scriptable Asset implementing ItemAssetBase<TModel> where TModel is the Model for the GunAgent

```
[CreateAssetMenu]
public class GunAsset : ItemAssetBase<SwordModel>
{
	public override IItemAgent CreateAgent()
    {
        return new SwordAgent(Model);
    }
}
```

A Weapon need to be picked up and used. The next step will allow it.

4. Right click in the Project view, `Create > GunAsset` and configure it.
5. Create a GameObject and attach the `ItemSceneView` component on it and select your Item asset.
