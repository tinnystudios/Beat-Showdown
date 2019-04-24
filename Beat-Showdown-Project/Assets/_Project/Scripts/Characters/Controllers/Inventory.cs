using System.Collections.Generic;

public class Inventory
{
    public List<Item> Items = new List<Item>();

    public Inventory()
    {

    }

    public void Add(Item item)
    {
        Items.Add(item);
    }
}