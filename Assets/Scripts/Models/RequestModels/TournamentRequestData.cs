using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTournamentRequestData
{
    public CreateTournamentRequestData(string gameId, string eventName, string eventType, string averagePurse, string firstPlaceAvgPrize, string secondPlaceAvgPrize, string thirdPlaceAvgPrize, string eventLength, string eventStartTimeStamp)
    {
        this.gameId = gameId;
        this.eventName = eventName;
        this.eventType = eventType;
        this.averagePurse = averagePurse;
        this.firstPlaceAvgPrize = firstPlaceAvgPrize;
        this.secondPlaceAvgPrize = secondPlaceAvgPrize;
        this.thirdPlaceAvgPrize = thirdPlaceAvgPrize;
        this.eventLength = eventLength;
        this.eventStartTimeStamp = eventStartTimeStamp;
    }

    public string gameId { get; set; }
    public string eventName { get; set; }
    public string eventType { get; set; }
    public string averagePurse { get; set; }
    public string firstPlaceAvgPrize { get; set; }
    public string secondPlaceAvgPrize { get; set; }
    public string thirdPlaceAvgPrize { get; set; }
    public string eventLength { get; set; }
    public string eventStartTimeStamp { get; set; }

    


    public Dictionary<string, string> GetRequestParams()
    {
        return new Dictionary<string, string>() {
                    {"gameId", gameId},
                    {"eventName", eventName},
                    {"eventType", eventType},
                    {"averagePurse", averagePurse},
                    {"firstPlaceAvgPrize", firstPlaceAvgPrize},
                    {"secondPlaceAvgPrize", secondPlaceAvgPrize},
                    {"thirdPlaceAvgPrize", thirdPlaceAvgPrize},
                    {"eventLength", eventLength},
                    {"eventStartTimeStamp", eventStartTimeStamp},

                };
    }

}


public class UserTournamentRequestData
{
    public UserTournamentRequestData(string tournamnentId, string userId)
    {
        this.tournamentId = tournamnentId;
        this.userId = userId;
    }

    public string tournamentId { get; set; }
    public string userId { get; set; }
    



    public Dictionary<string, string> GetRequestParams()
    {
        return new Dictionary<string, string>() {
                    {"tournamentId", tournamentId},
                    {"userId", userId},
                };
    }
}

