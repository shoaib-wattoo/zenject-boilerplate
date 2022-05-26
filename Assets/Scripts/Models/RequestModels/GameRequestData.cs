using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewGameRequestData
{
    public string title;
    public string subtitle;
    public string points;
    public string description;

    public AddNewGameRequestData(string title, string subtitle, string points, string description)
    {
        this.title = title;
        this.subtitle = subtitle;
        this.points = points;
        this.description = description;
    }


    public Dictionary<string, string> GetRequestParams()
    {
        return new Dictionary<string, string>() {
                    {"title", title},
                    {"subtitle", subtitle},
                    {"points", points},
                    {"description", description}
                };
    }

}

