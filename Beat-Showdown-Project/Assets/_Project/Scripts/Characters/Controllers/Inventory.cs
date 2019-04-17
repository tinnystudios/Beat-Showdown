using System.Collections.Generic;
using App.Items.Models;

public class Inventory
{
    public List<ItemModel> Items = new List<ItemModel>();

    public Inventory()
    {

    }

    public void Add(ItemModel item)
    {
        Items.Add(item);
    }
}