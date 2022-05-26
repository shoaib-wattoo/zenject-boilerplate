using System.Collections.Generic;
using System;

public class What
{
    public string Label { get; set; }
    public string Value { get; set; }
}

public class Type
{
    public string Value { get; set; }
    public string Label { get; set; }
}

public class Identifier
{
    public string label { get; set; }
    public int value { get; set; }
}

public class Source
{
    public string label { get; set; }
    public int value { get; set; }
}

public class Prize
{
    public object value { get; set; }
    public string label { get; set; }
    public string _id { get; set; }
    public Type type { get; set; }
    public int? amount { get; set; }
    public DateTime? expiration { get; set; }
    public Identifier identifier { get; set; }
    public Source source { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
    public int? __v { get; set; }
}

public class AchievementData
{
    public string _id { get; set; }
    public List<string> Leagues { get; set; }
    public string Title_1 { get; set; }
    public string Title_2 { get; set; }
    public string AchievementMessage { get; set; }
    public string NotificationMessage { get; set; }
    public What What { get; set; }
    public Prize Prize { get; set; }
    public int Quantity { get; set; }
    public DateTime Expiration { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int V { get; set; }
}

public class Achievements
{
    public bool Claimed { get; set; }
    public string completedPercentage { get; set; }
    public string _id { get; set; }
    public AchievementData Achievement { get; set; }
    public DateTime ClaimedDate { get; set; }
}

public class AchievementsData
{
    public string _id { get; set; }
    public List<Achievements> Achievements { get; set; }
}