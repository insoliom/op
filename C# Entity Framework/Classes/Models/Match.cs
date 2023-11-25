class Match
{
    public Match(int matchId, string country, DateOnly dateOfHolding, (int, int) score, int team1Id, int team2Id)
    {
        MatchId = matchId;
        Country = country;
        DateOfHolding = dateOfHolding;
        Score = score;
        Team1Id = team1Id;
        Team2Id = team2Id;
    }

    public int MatchId {get; set;}
    public string Country {get;set;}
    public DateOnly DateOfHolding {get; set;}
    public (int, int) Score {get; set;}
    public Team? Team1 { get; set; }
    public int Team1Id { get; set; }
    public Team? Team2 { get; set; }
    public int Team2Id { get; set; }   
    
}