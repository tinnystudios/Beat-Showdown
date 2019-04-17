using System.Collections.Generic;

public class Inventory
{
    public List<IItemAgent> Items = new List<IItemAgent>();

    public Inventory()
    {

    }

    public void Add(IItemAgent item)
    {
        Items.Add(item);
    }
}