class TeamWorker : AbstractWorker
{
    protected Team _team;
    public TeamWorker(Team team){
        _team = team;
    }

    public override string GetFullInfo(FanDatabase db) =>
        $"Full info of Team:\n" +
        $"Id: {_team.TeamId}\n" +
        $"Team Name: {_team.TeamName}\n" +
        $"DateOfFoundation: {_team.DateOfFoundation}\n" +
        $"List of Players: {string.Join("; ", _team.Players!)}\n"
        ;
/*
   class Team {
    public int TeamId {get; set;}
    public string TeamName {get;set;}
    public DateOnly DateOfFoundation {get; set;}
    public List<Player> Players {get; set;}
}
*/
    public override string GetBriefInfo() =>
        $"Brief info of Team:\n" +
        $"Team Name: {_team.TeamName}\n" +
        $"DateOfFoundation: {_team.DateOfFoundation}\n";
}