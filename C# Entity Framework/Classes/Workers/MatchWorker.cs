class MatchWorker : AbstractWorker
{
    protected Match _match;
    public MatchWorker(Match match){
        _match = match;
    }

    public override string GetFullInfo(FanDatabase db) =>
        $"Full info of Match:\n" +
        $"Id: {_match.MatchId}\n" +
        $"Country: {_match.Country}\n" +
        $"Date of holding: {_match.DateOfHolding}\n" +
        $"Teams: {db.Teams.Find(_match.Team1Id)!.TeamName} - {db.Teams.Find(_match.Team2Id)!.TeamName}\n" +
        $"Score: {_match.Score.Item1} - {_match.Score.Item2}\n"
        ;
        
    public override string GetBriefInfo() => 
        $"Breif info of Match (MatchId: {_match.MatchId}):\n" +
        $"Country: {_match.Country}\n" +
        $"{_match.Score.Item1} - {_match.Score.Item2}\n"
        ;
}