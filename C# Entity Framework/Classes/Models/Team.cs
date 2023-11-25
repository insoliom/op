class Team {
    public int TeamId {get; set;}
    public string? TeamName {get;set;}
    public DateOnly DateOfFoundation {get; set;}
    public List<Player>? Players {get; set;}

    public Team(int teamId, string? teamName, DateOnly dateOfFoundation)
    {
        TeamId = teamId;
        TeamName = teamName;
        DateOfFoundation = dateOfFoundation;
        Players = new List<Player>();
    }
}