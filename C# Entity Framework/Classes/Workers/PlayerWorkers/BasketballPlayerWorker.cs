class BasketballPlayerWorker : PlayerWorker
{
    public BasketballPlayerWorker(Player player) : base(player)
    {
        _player = player;
    }
    public override string getAdditionalInfo()
    {
        string additionalInfo = base.getAdditionalInfo();
        additionalInfo += "\nAll-Star Appearances: " + _player.AdditionalInfo!["All-Star"];
        additionalInfo += "\nAssists: " + _player.AdditionalInfo["Assists"];
        additionalInfo += "\nRebounds: " + _player.AdditionalInfo["Rebounds"];
        return additionalInfo;
    }
    public override void ChangeAdditionalInfo(string key, string value)
    {
        base.ChangeAdditionalInfo(key, value);
    }
    public override void FillAdditionalInfo()
    {
        base.FillAdditionalInfo();
        System.Console.WriteLine("We have a basketball player, so: \n");
        while (true)
        {
            System.Console.Write("Rebounds: ");
            if(int.TryParse(System.Console.ReadLine(), out int rebounds))
            {
                if(_player.AdditionalInfo["Rebounds"] is null)
                {
                    _player.AdditionalInfo!.Add("Rebounds", rebounds.ToString());
                }
                else 
                {
                    _player.AdditionalInfo["Rebounds"] = rebounds.ToString();
                }
                break;
            }
            else
            {
                System.Console.WriteLine("Thats not a number, try again: ");
            }
        }
        while (true)
        {
            System.Console.Write("Assists: ");
            
            if(int.TryParse(System.Console.ReadLine(), out int assists))
            {
                if(_player.AdditionalInfo["Assists"] is null)
                {
                    _player.AdditionalInfo!.Add("Assists", assists.ToString());
                }
                else 
                {
                    _player.AdditionalInfo["Assists"] = assists.ToString();
                }
                break;
            }
            else
            {
                System.Console.WriteLine("Thats not a number, try again: ");
            }
        }
        while (true)
        {
            System.Console.Write("All-Star Appearances: ");
            string allStar = System.Console.ReadLine()!;
            if(allStar != String.Empty && allStar is not null)
            {
                if(_player.AdditionalInfo["All-Star"] is null)
                {
                    _player.AdditionalInfo!.Add("All-Star", allStar.ToString());
                }
                else 
                {
                    _player.AdditionalInfo["All-Star"] = allStar.ToString();
                }
                break;
            }
            else 
            {
                System.Console.WriteLine("This player doesn't have any All-Star Appearances, right? (y/n)");
                bool check = System.Console.ReadLine() == "y" ? true : false;
                if(check)
                {
                    if(_player.AdditionalInfo["All-Star"] is null)
                    {
                        _player.AdditionalInfo!.Add("All-Star", " ");
                        break;
                    }
                    else 
                    {
                        _player.AdditionalInfo["All-Star"] = " ";
                    }
                    break;
                }
                else
                {
                    System.Console.WriteLine("Try again: ");
                }
            }
        }
    }
}