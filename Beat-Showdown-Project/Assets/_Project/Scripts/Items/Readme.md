## Items

### Breakdown:

Items are structured using MVC with an addition of Scriptable Objects refered to as Asset.

**Agent:** Actions, such as firing a bullet.

**Model:** Containing the data, such as the bullet to fire and the force

**Asset:** A Scriptable Object containing the Model and creates an Agent with the correct model. Can be configure in the editor.

### Usage
```

// To pick up an item, we need to receive the IItemAssetAgent from User Input
public void PickUp(IItemAssetAgent itemAssetAgent)
{
    // This allows us to create an agent with the correct type without knowing the type
    var itemAgent = itemAssetAgent.CreateAgent();
    
    BindItem(itemAgent);
    UseItem(itemAgent);
}

// Usage of an item can be acess through the IItemAgent interface
public void UseItem(IItemAgent itemAgent)
{
	itemAgent.Use();
}

// Binding any data an item interface depends on, this is Unique to your game
public void BindItem(IItemAgent itemAgent)
{
	GetInterface<IBind<ICharacterStatus>>?.Bind(Status);
}
```

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
Creating a weapon will introduce two new concepts.

#### Concepts
1. EquipmentBaseAgent<TModel> : Returns a View which instantiates a Prefab for the Equipment
2. EquipmentBaseModel : Contains prefab of type ItemSceneView

#### Let's Make the Weapon
1. Create an Agent implementing EquipmentBaseAgent<TModel> where TModel is the Model relating to your Agent

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

3. Create an Item Asset implementing ItemAssetBase<TModel> where TModel is the Model for the GunAgent

```
[CreateAssetMenu]
public class GunAsset : ItemAssetBase<GunModel>
{
    public override IItemAgent CreateAgent()
    {
        return new SwordAgent(Model);
    }
}
```

4. Right click in the Project view, `Create > GunAsset` and configure it.
5. Create a GameObject and attach the `ItemSceneView` component on it and select your Item asset.

The difference between a Potion which is consumerable and an Equipment is that there needs to be a Scene Prefab for the Equipment.
