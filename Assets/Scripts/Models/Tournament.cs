using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TournamentOld
{
    public long createdAt { get; set; }
    public long updatedAt { get; set; }
    public string id { get; set; }
    public string gameId { get; set; }
    public string eventId { get; set; }
    public string eventName { get; set; }
    public string eventType { get; set; }
    public int averagePurse { get; set; }
    public int firstPlaceAvgPrize { get; set; }
    public int secondPlaceAvgPrize { get; set; }
    public int thirdPlaceAvgPrize { get; set; }
    public User[] users { get; set; }
    public int eventLength { get; set; }
    public long remainingTime { get; set; }
    public long eventStartTimeStamp { get; set; }
    public string status { get; set; }
}

public class FirstPlaceAvgPrize
{
    public string value { get; set; }
    public string label { get; set; }
}

public class SecondPlaceAvgPrize
{
    public string value { get; set; }
    public string label { get; set; }
}

public class Start
{
    public int hours { get; set; }
    public int minutes { get; set; }
}

public class End
{
    public int hours { get; set; }
    public int minutes { get; set; }
}

public class DaysOfWeekTime
{
    public Start start { get; set; }
    public End end { get; set; }
}

public class GameTheme
{
    public string value { get; set; }
    public string label { get; set; }
}

public class Game
{
    public string _id { get; set; }
    public string title { get; set; }
    public string subtitle { get; set; }
    public string points { get; set; }
    public string description { get; set; }
    public string status { get; set; }
}

public class GameDropdown
{
    public string value { get; set; }
    public string label { get; set; }
}

public class Tournament
{
    public string _id { get; set; }
    public List<string> leagueIds { get; set; }
    public List<string> daysOfWeek { get; set; }
    public string gameId { get; set; }
    public string eventName { get; set; }
    public string eventType { get; set; }
    public int averagePurse { get; set; }
    public FirstWager firstWager { get; set; }
    public SecondWager secondWager { get; set; }
    public FirstPlaceAvgPrize firstPlaceAvgPrize { get; set; }
    public SecondPlaceAvgPrize secondPlaceAvgPrize { get; set; }
    public object thirdPlaceAvgPrize { get; set; }
    public int eventLength { get; set; }
    public long eventStartTimeStamp { get; set; }
    public long eventEndTimeStamp { get; set; }
    public string status { get; set; }
    public int maxPlayers { get; set; }
    public int minPlayers { get; set; }
    public int payout { get; set; }
    public float pointPerMinute { get; set; }
    public DaysOfWeekTime daysOfWeekTime { get; set; }
    public int freePlayByIn { get; set; }
    public GameTheme gameTheme { get; set; }
    public float secondaryPointTarget { get; set; }
    public int primaryPointTarget { get; set; }
    public string eventId { get; set; }
    public string seasonId { get; set; }
    public int __v { get; set; }
    public Game game { get; set; }
    public User[] users { get; set; }
    public int remainingTime { get; set; }
}

public class FirstWager
{
    public string id { get; set; }
    public int wager { get; set; }
}

public class SecondWager
{
    public string id { get; set; }
    public int wager { get; set; }
}