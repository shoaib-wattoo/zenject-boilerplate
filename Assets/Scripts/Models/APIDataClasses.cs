using System;
using System.Collections.Generic;
using UnityEngine;

public class GameType
{
    public string value;
    public string label;

    public GameType(string value, string label)
    {
        this.value = value;
        this.label = label;
    }
}

public class CreateChallengegData
{
    public CreateChallengegData(GameType gameType, string pointTarget, string timeLimit, string firstWager, string secondWager, string from, string to, string title, string type, string seasonId)
    {
        this.gameType = gameType;
        this.pointTarget = pointTarget;
        this.timeLimit = timeLimit;
        this.firstWager = firstWager;
        this.secondWager = secondWager;
        this.from = from;
        this.to = to;
        this.title = title;
        this.type = type;
        this.seasonId = seasonId;
    }

    public GameType gameType { get; set; }
    public string pointTarget { get; set; }
    public string timeLimit { get; set; }
    public string firstWager { get; set; }
    public string secondWager { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public string seasonId { get; set; }


    public Dictionary<string, string> GetRequestParams()
    {
        return new Dictionary<string, string>() {
                    {"gameType", JsonUtility.ToJson(gameType)},
                    {"pointTarget", pointTarget},
                    {"timeLimit", timeLimit},
                    {"firstWager", firstWager},
                    {"secondWager", secondWager},
                    {"from", from},
                    {"to", to},
                    {"title", title},
                    {"type", type},
                    {"seasonId", seasonId}
                };
    }

}


[Serializable]
public class AcceptChallengedata
{
    public AcceptChallengedata(string id, bool accepted, GameSeedAndScore challenger, GameSeedAndScore opponent)
    {
        this.id = id;
        this.accepted = accepted;
        this.challenger = challenger;
        this.opponent = opponent;
    }

    public string id { get; set; }
    public bool accepted { get; set; }
    public GameSeedAndScore challenger { get; set; }
    public GameSeedAndScore opponent { get; set; }
}

[Serializable]
public class AcceptRequest
{
    public AcceptRequest(string requestId, string recordId, string userId, bool accept)
    {
        this.requestId = requestId;
        this.recordId = recordId;
        this.userId = userId;
        this.accept = accept;
    }

    public string requestId { get; set; }
    public string recordId { get; set; }
    public string userId { get; set; }
    public bool accept { get; set; }
}


public class Id
{
    public string userId { get; set; }
    public string seasonId { get; set; }
    public string leagueId { get; set; }
}

public class SeasonAward
{
    public string _id { get; set; }
    //public string type { get; set; }
    public int value { get; set; }
    public int amount { get; set; }
    public DateTime expiration { get; set; }
    //public string identifier { get; set; }
    public string label { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int __v { get; set; }
}

public class Icon
{
    public string fieldname { get; set; }
    public string originalname { get; set; }
    public string encoding { get; set; }
    public string mimetype { get; set; }
    public string destination { get; set; }
    public string filename { get; set; }
    public string path { get; set; }
    public int size { get; set; }
}

public class Leaderboard
{
    public Id _id { get; set; }
    public int totalWinningAmount { get; set; }
    public float avgPrizeAmount { get; set; }
    public float avgPoints { get; set; }
    public int totalGamesPlayed { get; set; }
    public float avgPosition { get; set; }
    public int totalPlayCount { get; set; }
    public int winCount { get; set; }
    public int totalPoints { get; set; }
    public string userName { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string leagueName { get; set; }
    public List<SeasonAward> seasonAwards { get; set; }
    public int seasonTotalPoints { get; set; }
    public int seasonTotalAmount { get; set; }
    public string userAvatar { get; set; }
    public Icon icon { get; set; }
}

public class LeaderboardData
{
    public List<Leaderboard> globalLeaderBoardData { get; set; }
    public List<Leaderboard> friendsLeaderBoardData { get; set; }
    public List<Leaderboard> LeagueLeaderBoardData1 { get; set; }
}

public class LeagueData
{
    public string _id { get; set; }
    public string name { get; set; }
    public string seasonId { get; set; }
    public int averagePurse { get; set; }
    public int NumberOfPlayers { get; set; }
    public LeagueIcon image { get; set; }
    public LeagueIcon leagueIcon { get; set; }

    public string leagueName { get; set; }
    public int totalEarnings { get; set; }
}

public class LeagueIcon
{
    public string fieldname { get; set; }
    public string originalname { get; set; }
    public string encoding { get; set; }
    public string mimetype { get; set; }
    public string destination { get; set; }
    public string filename { get; set; }
    public string path { get; set; }
    public string size { get; set; }


}

public class Leagues
{
   public List<LeagueData> leagues { get; set; }
}

public class LeaderboardRequest
{
    public string id;

    public LeaderboardRequest(){}

    public LeaderboardRequest(string id)
    {
        this.id = id;
    }
}

public class TournamentAndChallengeRequest
{
    public string leagueId;
    public string userId;

    public TournamentAndChallengeRequest() { }

    public TournamentAndChallengeRequest(string id, string leagueId)
    {
        this.userId = id;
        this.leagueId = leagueId;

    }
}

public class Season
{
    public string _id { get; set; }
    public string status { get; set; }
    public string name { get; set; }
    public long endTimeStamp { get; set; }
    public long startTimeStamp { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int __v { get; set; }
}

public class SeasonAndLeague
{
    public Season seasonData;
    public LeagueData leagueData;

}

public class UserStat
{
    public double lifetimeWinPercentage { get; set; }
    public int lifeTimeEarnings { get; set; }
    public int noOfFirstPos { get; set; }
    public int countOfGame { get; set; }
    public int seasonEarnings { get; set; }
    public string currentLeagueName { get; set; }
    public int seasonGamesPlayed { get; set; }
    public int seasonWinnings { get; set; }
}

public class UserProfile
{
    public User user { get; set; }
    public List<UserStat> userStats { get; set; }
}

public class Tile
{
    public int value { get; set; }
    public string label { get; set; }
}

public class BrandImage
{
    public string fieldname { get; set; }
    public string originalname { get; set; }
    public string encoding { get; set; }
    public string mimetype { get; set; }
    public string destination { get; set; }
    public string filename { get; set; }
    public string path { get; set; }
    public int size { get; set; }
}

public class MarketPlaceData
{
    public string _id { get; set; }
    public string type { get; set; }
    public float amount { get; set; }
    public string userId { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int __v { get; set; }
}

public class BrandMenu
{
    public string _id { get; set; }
    public string title { get; set; }
    public BrandImage image { get; set; }
}

public class BrandDashBoard
{
    public string _id { get; set; }
    public string title { get; set; }
    public BrandImage image { get; set; }
    public List<BrandMenu> menu { get; set; }
}

public class BrandData
{
    public string _id { get; set; }
    public Tile tile { get; set; }
    public string title { get; set; }
    public BrandImage image { get; set; }
    public int __v { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public List<BrandDashBoard> dashBoard { get; set; }
}

public class EventTime
{
    public Start start { get; set; }
    public End end { get; set; }
}

public class RecordEntryInfo
{
    public string day { get; set; }
    public int hours { get; set; }
    public int minutes { get; set; }
    public int date { get; set; }
    public int month { get; set; }
    public DateTime fullDate { get; set; }
}

public class MyPosition
{
    public string leagueId { get; set; }
    public string tournamentId { get; set; }
    public string seasonId { get; set; }
    public string gameId { get; set; }
    public string userId { get; set; }
    public int eventId { get; set; }
    public int prizeAmount { get; set; }
    public int award { get; set; }
    public int points { get; set; }
    public int freePlayPoints { get; set; }
    public int freePlayAmount { get; set; }
    public RecordEntryInfo recordEntryInfo { get; set; }
    public int position { get; set; }
    public bool winner { get; set; }
    public TournamentPrize prize { get; set; }
}

public class TournamentPrize
{
    public string _id { get; set; }
    public Type type { get; set; }
    public int value { get; set; }
    public int amount { get; set; }
    public DateTime expiration { get; set; }
    public string identifier { get; set; }
    public string label { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int __v { get; set; }
}

public class GameWinner
{
    public Id _id { get; set; }
    public int totalWinningAmount { get; set; }
    public double avgPrizeAmount { get; set; }
    public double avgPoints { get; set; }
    public int totalGamesPlayed { get; set; }
    public double avgPosition { get; set; }
    public int totalPlayCount { get; set; }
    public int winCount { get; set; }
    public int totalPoints { get; set; }
    public string userName { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userAvatar { get; set; }
    public string leagueName { get; set; }
    public Icon icon { get; set; }
    public int seasonTotalPoints { get; set; }
    public int seasonTotalAmount { get; set; }
}

public class TournamentDetail
{
    public string _id { get; set; }
    public string leagueName { get; set; }
    public string tournamentName { get; set; }
    public string eventId { get; set; }
    public long eventStartTime { get; set; }
    public long eventEndTime { get; set; }
    public EventTime eventTime { get; set; }
    public List<MyPosition> myPosition { get; set; }
    public List<GameWinner> gameWinners { get; set; }
    public DateTime createdAt { get; set; }
}

public class Location
{
    public float latitude;
    public float longitude;

    public Location(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }
}

public class ScoreBoard
{
    public string _id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
    public int eventId { get; set; }
    public bool winner { get; set; }
    public int prizeAmount { get; set; }
    public int award { get; set; }
    public int points { get; set; }
    public int freePlayPoints { get; set; }
    public int freePlayAmount { get; set; }
    public bool runnerUp { get; set; }
    public bool challenge { get; set; }
    public bool claimed { get; set; }
    public string tournamentId { get; set; }
    public string seasonId { get; set; }
    public string gameId { get; set; }
    public string userId { get; set; }
    public string day { get; set; }
    public RecordEntryInfo recordEntryInfo { get; set; }
    public int position { get; set; }
    public int __v { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string userAvatar { get; set; }
}

public class ChallengeDetail
{
    public string _id { get; set; }
    public List<ScoreBoard> scoreBoard { get; set; }
    public FirstWager firstWager { get; set; }
    public SecondWager secondWager { get; set; }
    public GameTheme gameTheme { get; set; }
    public string eventName { get; set; }
    public int eventId { get; set; }
}

public class GeoFenceTime
{
    public object hours { get; set; }
    public object minutes { get; set; }
}

public class GeoFenceTrigger
{
    public string label { get; set; }
    public int value { get; set; }
}

public class GeoFenceLocation
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class GeoFence
{
    public List<string> types { get; set; }
    public string _id { get; set; }
    public string name { get; set; }
    public string label { get; set; }
    public string value { get; set; }
    public GeoFenceLocation location { get; set; }
    public string search_point { get; set; }
    public string radius { get; set; }
    public string place_Id { get; set; }
    public string vicinity { get; set; }
    public string icon_mask_base_uri { get; set; }
    public string icon { get; set; }
    public string icon_background_color { get; set; }
}

public class GeoFenceImage
{
    public string fieldname { get; set; }
    public string originalname { get; set; }
    public string encoding { get; set; }
    public string mimetype { get; set; }
    public string destination { get; set; }
    public string filename { get; set; }
    public string path { get; set; }
    public int size { get; set; }
    public object thumbnail { get; set; }
}

public class GeoFenceUsersRespond
{
    public string status { get; set; }
    public string _id { get; set; }
    public string user { get; set; }
    public DateTime time { get; set; }
}

public class GeoFenceWishListData
{
    public string _id { get; set; }
    /*public bool pauseNotification { get; set; }
    public bool selectAllLeagues { get; set; }
    public bool selectNon { get; set; }
    public List<string> leagues { get; set; }
    public List<string> sendToUsers { get; set; }
    public List<object> engageUsers { get; set; }
    public List<object> claimedByUsers { get; set; }
    public List<string> geoFenceUsers { get; set; }
    public string title { get; set; }
    public string message { get; set; }
    public GeoFenceTime time { get; set; }
    public DateTime date { get; set; }
    public object dateUTC { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public GeoFenceTrigger trigger { get; set; }
    public GeoFence geoFence { get; set; }
    public GeoFenceImage image { get; set; }
    public List<GeoFenceUsersRespond> usersRespond { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int notificationId { get; set; }
    public int __v { get; set; }*/
}