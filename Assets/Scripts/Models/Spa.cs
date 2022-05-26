using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaMenu    {
    public string name { get; set; } 
    public int price { get; set; } 
}

public class ServiceMenu    {
    public string name { get; set; } 
    public string description { get; set; } 
    public List<SpaMenu> menu { get; set; } 
}

public class Spa    {
    public string id { get; set; } 
    public string name { get; set; } 
    public string type { get; set; } 
    public string category { get; set; } 
    public string location { get; set; } 
    public List<ServiceMenu> serviceMenu { get; set; } 
}

