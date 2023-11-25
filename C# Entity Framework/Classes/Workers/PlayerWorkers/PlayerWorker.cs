class PlayerWorker : AbstractWorker
{
    protected Player _player;
    public PlayerWorker(Player player){
        _player = player;
    }
    public virtual string getAdditionalInfo() =>
         $"Additional info about {_player.FullName} (sport - {_player.Sport})";
    
    public virtual void ChangeAdditionalInfo(string key, string value) {
        System.Console.WriteLine($"Change additional information with the '{key}' key to {value}");
        
        if(_player.AdditionalInfo["key"] is null){
            System.Console.WriteLine("Error! wrong key for additional info.");
        }  
        else {
            _player.AdditionalInfo["key"] = value;
        }
    }

    public virtual void FillAdditionalInfo() =>
        System.Console.WriteLine($"Lets fill in additional info about {_player.FullName}:");

    public override string GetFullInfo(FanDatabase db) =>
        $"Full info of Player:\n" +
        $"Id: {_player.PlayerId}\n" +
        $"Full Name: {_player.FullName}\n" +
        $"Sport: {_player.Sport}\n" +
        $"Team: {new TeamWorker(db.Teams.Find(_player.TeamId)!).GetBriefInfo()}\n" +
        $"Citizenship: {_player.Citizenship}\n" +
        $"Origin Country: {_player.OriginCountry}\n" +
        $"Date Of Birth: {_player.DateOfBirth}\n"
        ;
    public override string GetBriefInfo() =>
        $"Id: {_player.PlayerId}\n" +
        $"Full Name: {_player.FullName}\n" +
        $"Citizenship: {_player.Citizenship}\n";
}