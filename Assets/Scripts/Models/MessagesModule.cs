using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MessagesModule
{
}

public class CreatePredefinedMsgData
{
    public CreatePredefinedMsgData(string message, string title, string type)
    {
        this.message = message;
        this.title = title;
        this.type = type;
    }

    public string message { get; set; }
    public string title { get; set; }
    public string type { get; set; }

    public Dictionary<string, string> GetRequestParams()
    {
        return new Dictionary<string, string>() {
                    {"message", message},
                    {"title", title},
                    {"type", type}
                };
    }

}

public class PredefineMsg
{
    public string _id { get; set; }
    public string message { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public int __v { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class BetWeen
{
    public string _id { get; set; }
    public User userId { get; set; }
}

public class UnSeenCount
{
    public string _id { get; set; }
    public string userId { get; set; }
    public int count { get; set; }
}

public class Message
{
    public object files { get; set; }
    public string _id { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    public string message { get; set; }
    public string subject { get; set; }
    public DateTime time { get; set; }
    public string date { get; set; }
}

public class MessageData
{
    public string _id { get; set; }
    public List<BetWeen> betWeen { get; set; }
    public List<UnSeenCount> unSeenCount { get; set; }
    public Message message { get; set; }
}


