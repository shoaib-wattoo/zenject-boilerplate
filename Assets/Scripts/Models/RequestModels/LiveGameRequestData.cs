using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinLiveGameRequestData
{
    public string userId;
    public string gameId;
    public string tournamentId;
    public string seed;
    public string finalScore;

    public JoinLiveGameRequestData(string userId, string gameId, string tournamentId, string seed, string finalScore)
    {
        this.userId = userId;
        this.gameId = gameId;
        this.tournamentId = tournamentId;
        this.seed = seed;
        this.finalScore = finalScore;
    }
    public Dictionary<string, string> GetRequestParams()
    {
        return new Dictionary<string, string>() {
                    {"userId", userId},
                    {"gameId", gameId},
                    {"tournamentId", tournamentId},
                    {"seed", seed},
                    {"finalScore", finalScore},
                };
    }
}
