using Microsoft.EntityFrameworkCore;

class TeamRepository : AbstractRepository<Team>{
    public TeamRepository(FanDatabase context):base(context){}
    public static TeamRepository operator +(TeamRepository obj, Team team)
    {
        obj._dbContext.Add(team);
        obj._dbContext.SaveChanges();
        return obj;
    }
    public static TeamRepository operator -(TeamRepository obj, int teamId)
    {
        Team? toDelete = obj._dbContext.Find<Team>(teamId);
        if (toDelete is not null){
            obj._dbContext.Remove<Team>(toDelete);
        }
        else {
            System.Console.WriteLine($"Team with id = {teamId} does not exist.");
        }
        obj._dbContext.SaveChanges();
        return obj;
    }
    public List<Team> GetTeams() => _dbContext.Teams.AsNoTracking().ToList();
    public override string GetGeneralInfo(int id)
    {
        Team team = _dbContext.Teams.Find(id)!;
        if(team is null) {
            System.Console.WriteLine($"team with id {id} does not exist.");
            return "";
        }
        string generalInfo = "General info: \n";
        generalInfo += $"Players amount: {team.Players!.Count()} \n";
        generalInfo += $"List of players: {string.Join("; ", team.Players!.Select(p => $"\nid: {p.PlayerId}; Full name: {p.FullName}"))}";
        generalInfo += $"\nWins: {_dbContext.Matches.Where(m => m.Team1Id == id && m.Score.Item1 > m.Score.Item2 || m.Team2Id == id && m.Score.Item2 > m.Score.Item1).Count()} \n";
        var matches = _dbContext.Matches.Where(m => m.Team1Id == id || m.Team2Id == id);
        try
        {
            MatchWorker matchWorker = new MatchWorker(matches.OrderBy(m => m.DateOfHolding).Last());
            generalInfo += $"Last match:\n{matchWorker.GetBriefInfo()} \n";
        }
        catch
        {
            generalInfo += "This team has no players.";
        }
        return generalInfo;
    }
    public override Team GetById(int id)
    {
        return _table.Find(id);
    }
    public override void RemoveById(int id)
    {
        Team teamToRemove = _table.Find(id);
        if (teamToRemove is not null)
        {
            _table.Remove(teamToRemove);
        }
        _dbContext.SaveChanges();
    }
    public override void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}