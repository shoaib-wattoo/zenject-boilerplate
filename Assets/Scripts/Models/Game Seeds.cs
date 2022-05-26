public class GameSeeds
{
    public int prizeAmount { get; set; }
    public string _id { get; set; }
    public string userId { get; set; }
    public string gameId { get; set; }
    public string tournamentId { get; set; }
    public int seed { get; set; }
    public double finalScore { get; set; }
    public int __v { get; set; }
    public int position { get; set; }
    public bool winner { get; set; }
    public int award { get; set; }
    public string challengeId { get; set; }
}

public class PrizeType
{
    public string value { get; set; }
    public string label { get; set; }
}

public class SeedPrize
{
    public string _id { get; set; }
    public PrizeType type { get; set; }
    public int value { get; set; }
    public int amount { get; set; }
    public string identifier { get; set; }
    public string label { get; set; }
    public int __v { get; set; }
}