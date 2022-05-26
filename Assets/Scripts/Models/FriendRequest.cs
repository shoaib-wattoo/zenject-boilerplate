using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserId
{
    public string _id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
}

public class Request
{
    public string _id { get; set; }
    public string requestStatus { get; set; }
    public UserId userId { get; set; }
    public string requestType { get; set; }
    public long requestTime { get; set; }
}

public class FriendRequest
{
    public string _id { get; set; }
    public List<Request> requests { get; set; }
}

public class Friend
{
    public string _id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
}

public class Friends
{
    public string _id { get; set; }
    public List<Friend> friends { get; set; }
}

public class RequestData
{
    public string _id { get; set; }
    public string requestStatus { get; set; }
    public string userId { get; set; }
    public string requestType { get; set; }
    public long requestTime { get; set; }
}

public class SendRequestData
{
    public List<string> friends { get; set; }
    public string _id { get; set; }
    public string userId { get; set; }
    public int __v { get; set; }
    public List<RequestData> requests { get; set; }
}