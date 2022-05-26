using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AvatarImageSaver
{
    public string id;
    public Sprite avatarImage;
    public Sprite avatarImageBorder;

    public AvatarImageSaver(string id, Sprite horseImage, Sprite horseImageBorder)
    {
        this.id = id;
        this.avatarImage = horseImage;
        this.avatarImageBorder = horseImageBorder;
    }
}

[Serializable]
public class GameSeedAndScore
{
    public int seed;
    public float finalScore;
}

public enum GamesType
{
    HORSEGAME,
    ATWGAME,
    SPACEGAME
}

public enum TournamentType
{
    CHALLENGE,
    TOURNAMENT
}

public enum GameAvatarVersion
{
    FIRST,
    SECOND
}

public class GamesService
{
    public GamesType currentGame = GamesType.ATWGAME;
    GameAvatarVersion crrentAvatarVersion = GameAvatarVersion.SECOND;
    public Tournament currentTournament;
    public Tournament selectedTournamentforHistoricalEvent;
    public Sprite currentgameAvatar;
    public List<GameSeeds> currentGameSeeds;

    public static string HorseGameID = "6184db40711dbf3da62a6974";
    public static string ATWGameID = "618e062e662c3b5e9892e09b";
    public static string SpaceGameID = "618e060c662c3b5e9892e09a";

    #region HORSE GAME
    public float horseGameSpeedPeriod = 2.5f;
    public float horseGameMinSpeed = 0.8f;
    public float horseGameMaxSpeed = 1.2f;
    public int horseGameNoOfRandomValue = 50;
    public int horseGameSeed = 0;
    public float horseGameFinalScore = 0;
    public bool startGame;
    public List<AvatarImageSaver> avatarImageSaver = new List<AvatarImageSaver>();

    public float atwGameSpeedPeriod = 1.5f;
    public float atwGameMinSpeed = 0.8f;
    public float atwGameMaxSpeed = 1.2f;
    public int atwGameNoOfRandomValue = 50;

    public float spaceGameSpeedPeriod = 2.5f;
    public float spaceGameMinSpeed = 0.8f;
    public float spaceGameMaxSpeed = 1.2f;
    public int spaceGameNoOfRandomValue = 30;

    public float gameSpeedPeriod
    {
        get {
            if (currentTournament.gameId == HorseGameID)
                return horseGameSpeedPeriod;
            else if (currentTournament.gameId == ATWGameID)
                return atwGameSpeedPeriod;
            else
                return spaceGameSpeedPeriod;
        }
    }

    public float gameMinSpeed
    {
        get
        {
            if (currentTournament.gameId == HorseGameID)
                return horseGameMinSpeed;
            else if (currentTournament.gameId == ATWGameID)
                return atwGameMinSpeed;
            else
                return spaceGameMinSpeed;
        }
    }

    public float gameMaxSpeed
    {
        get
        {
            if (currentTournament.gameId == HorseGameID)
                return horseGameMaxSpeed;
            else if (currentTournament.gameId == ATWGameID)
                return atwGameMaxSpeed;
            else
                return spaceGameMaxSpeed;
        }
    }

    public int gameNoOfRandomValue
    {
        get
        {
            if (currentTournament.gameId == HorseGameID)
                return horseGameNoOfRandomValue;
            else if (currentTournament.gameId == ATWGameID)
                return atwGameNoOfRandomValue;
            else
                return spaceGameNoOfRandomValue;
        }
    }

    /*
    public int GetMyRandomSeed()
    {
        if (horseGameSeed != 0)
            return horseGameSeed;

        horseGameSeed = UnityEngine.Random.Range(0, 1000);
        return horseGameSeed;
    }

    public float GetMyFinalScore()
    {
        if (horseGameFinalScore != 0)
            return horseGameFinalScore;

        RandomSequence randomSeqence = new System.RandomSequence(horseGameSeed, (int)(horseGameMinSpeed * 100), (int)(horseGameMaxSpeed * 100), Services.GamesService.horseGameNoOfRandomValue);

        for (int i = 0; i < horseGameNoOfRandomValue; i++)
        {
            Debug.Log("Random Sequence USerService : " + i + " - " + randomSeqence.getRandomSequenceNumber(i) / 100f);
        }

        for (int i = 0; i < horseGameNoOfRandomValue; i++)
        {
            horseGameFinalScore += (randomSeqence.getRandomSequenceNumber(i) / 100f) * horseGameSpeedPeriod;
        }

        return horseGameFinalScore;
    }
    */
    public void SelectGameOnTournamentSelection(Tournament tournament)
    {
        if(tournament.gameId == HorseGameID)
        {
            currentGame = GamesType.HORSEGAME;
        }

        if (tournament.gameId == ATWGameID)
        {
            currentGame = GamesType.ATWGAME;
        }

        if (tournament.gameId == SpaceGameID)
        {
            currentGame = GamesType.SPACEGAME;
        }
    }

    public GamesType GetGameType(Tournament tournament)
    {
        GamesType type = GamesType.HORSEGAME;
        if (tournament.gameId == HorseGameID)
        {
            type = GamesType.HORSEGAME;
        }

        if (tournament.gameId == ATWGameID)
        {
            type = GamesType.ATWGAME;
        }

        if (tournament.gameId == SpaceGameID)
        {
            type = GamesType.SPACEGAME;
        }

        return type;
    }

    

    public DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        unixTimeStamp /= 1000;
        System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
        return dtDateTime;
    }

    public float GetRemainingTime(long eventStartTimeStamp)
    {
        DateTime eventTime = UnixTimeStampToDateTime(eventStartTimeStamp).ToLocalTime();
        TimeSpan remainingTime = eventTime - DateTime.Now;
        return (float)remainingTime.TotalSeconds;
    }
    #endregion 
}
