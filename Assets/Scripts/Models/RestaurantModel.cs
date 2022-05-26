using System.Collections.Generic;

public class Menu
{
    public string dishName { get; set; }
    public int price { get; set; }
    public string quantity { get; set; }
    public int servingPerson { get; set; }
}

public class ServingType
{
    public string name { get; set; }
    public List<Menu> menu { get; set; }
}

public class Restaurant
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string category { get; set; }
    public string location { get; set; }
    public List<ServingType> servingTypes { get; set; }
}