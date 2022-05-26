using System;

public class ChallengeData
{
    public string requestStatus { get; set; }
    public string _id { get; set; }
    public int pointTarget { get; set; }
    public int timeLimit { get; set; }
    public int firstWager { get; set; }
    public int secondWager { get; set; }
    public User from { get; set; }
    public User to { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int __v { get; set; }
    public GameType gameType { get; set; }
}
