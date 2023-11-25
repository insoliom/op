using Microsoft.EntityFrameworkCore;

class PlayerRepository : AbstractRepository<Player>{
    public PlayerRepository(FanDatabase context):base(context){}
    public static PlayerRepository operator +(PlayerRepository obj, Player player)
    {
        obj._dbContext.Add<Player>(player);
        obj._dbContext.SaveChanges();
        return obj;
    }
    public void Remove(int playerId)
    {
        Player? toDelete = _table.Find(playerId);
        if (toDelete is not null)
        {
            _table.Remove(toDelete);
        }
        else 
        {
            System.Console.WriteLine($"Player with id = {playerId} does not exist.");
        }
    }
    public List<Player> GetPlayers() => _table.ToList();
    public override string GetGeneralInfo(int id)
    {
        Player? player = _table!.Find(id);
        
        string generalInfo = "General info about player: \n";

        if(player is not null)
        {
            generalInfo += $"Full name: {player.FullName}\n";
            generalInfo += $"Team: {_dbContext.Teams.FirstOrDefault(t => t.Players!.Contains(player))!.TeamName}\n";
            generalInfo += $"Citizenship: {player.Citizenship}\n";
            generalInfo += $"Origin Country: {player.OriginCountry}\n";
            generalInfo += $"Date Of Birth: {player.DateOfBirth}\n";
            generalInfo += $"Additional Info: ";
        }
        else
        {
            generalInfo = $"Player with id = {id} does not exist.";
        }
        return generalInfo;
    }

    public override Player GetById(int id)
    {
        return _table.Find(id);
    }

    public override void RemoveById(int id)
    {
        Player playerToRemove = _table.Find(id);
        if (playerToRemove is not null)
        {
            _table.Remove(playerToRemove);
        }
        _dbContext.SaveChanges();
    }

    public override void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}