﻿using App.Items.Models;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item/Gun")]
public class GunAsset : ItemAssetBase<GunModel>
{
    public GunAsset(GunModel model) : base(model)
    {

    }

    public override IItemAgent CreateAgent()
    {
        return new GunAgent(Model);
    }
}