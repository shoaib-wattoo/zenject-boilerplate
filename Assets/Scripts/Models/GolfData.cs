using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoard    {
    public string name { get; set; } 
    public string description { get; set; } 
}

public class GolfData    {
    public string id { get; set; } 
    public string name { get; set; } 
    public string type { get; set; } 
    public string category { get; set; } 
    public string location { get; set; } 
    public List<DashBoard> dashBoard { get; set; } 
}