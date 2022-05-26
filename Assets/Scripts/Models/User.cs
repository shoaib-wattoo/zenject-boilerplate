using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string _id { get; set; }
    public string fbid { get; set; }
    public string emailAddress { get; set; }
    public string emailStatus { get; set; }
    public string secondaryEmailAddress { get; set; }
    public string cellPhone { get; set; }
    public string secondaryCellPhone { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
    public string address_1 { get; set; }
    public string address_2 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zipCode { get; set; }
    public string country { get; set; }
    public string token { get; set; }
    public string fcmToken { get; set; }
    public string password { get; set; }
    public string userAvatar { get; set; }
    public string horseIcon { get; set; }
    public string airPlaneIcon { get; set; }
    public string spaceShipIcon { get; set; }
    public string leagueId { get; set; }

    public Dictionary<string, string> ToDic()
    {
        return new Dictionary<string, string>() {
                    {"id", _id},
                    {"secondaryEmailAddress", secondaryEmailAddress},
                    {"cellPhone", cellPhone},
                    {"secondaryCellPhone", secondaryCellPhone},
                    {"firstName", firstName},
                    {"lastName", lastName},
                    {"userName", userName},
                    {"address_1", address_1},
                    {"address_2", address_2},
                    {"city", city},
                    {"state", state},
                    {"zipCode", zipCode},
                    {"country", country},
                    {"fcmToken", fcmToken},
                    {"userAvatar", userAvatar},
                    {"horseIcon", horseIcon},
                    {"airPlaneIcon", airPlaneIcon},
                    {"spaceShipIcon", spaceShipIcon},
                    {"leagueId", leagueId}
                };
    }
}
