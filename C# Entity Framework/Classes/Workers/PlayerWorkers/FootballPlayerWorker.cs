using System.Dynamic;

class FootballPlayerWorker : PlayerWorker
{
    public FootballPlayerWorker(Player player) : base(player)
    {
        _player = player;
    }
    public override string getAdditionalInfo()
    {
        string additionalInfo = base.getAdditionalInfo();
        additionalInfo += "\nAwards: " + _player.AdditionalInfo!["Awards"];
        additionalInfo += "\nPosition: " + _player.AdditionalInfo["Position"];
        additionalInfo += "\nGoals: " + _player.AdditionalInfo["Goals"];
        return additionalInfo;
    }
    public override void ChangeAdditionalInfo(string key, string value)
    {
        base.ChangeAdditionalInfo(key, value);
    }
    public override string GetFullInfo(FanDatabase db)
    {
        string fullInfo = base.GetFullInfo(db) +
        getAdditionalInfo();
        return fullInfo;
    }
    public override void FillAdditionalInfo()
    {
        base.FillAdditionalInfo();
        System.Console.WriteLine("We have a football player, so: ");
        while (true)
        {
            System.Console.Write("Goals: ");
            if(int.TryParse(System.Console.ReadLine(), out int goals))
            {
                if(goals > 1000){
                    System.Console.WriteLine("Player with so large number of goals ");
                }
                _player.AdditionalInfo!["Goals"] = goals.ToString();
                break;
            }
            else
            {
                System.Console.WriteLine("Thats not a number, try again: ");
            }
        }
        while (true)
        {
            System.Console.WriteLine("Position: (type a number)");
            string[] positions = {"1: the goalkeeper", "2: full-back", "3: centre-back/sweeper", "4: defensive midfielder", 
                                "5: attacking midfielder", "6: second striker", "7: centre-forward", "8: substitute" };
                                
            System.Console.WriteLine(string.Join("\n", positions));
            if(int.TryParse(System.Console.ReadLine(), out int position))
            {
                if(position > 8 || position < 1){
                    System.Console.WriteLine("Please, type position from list (1 to 8)");
                    continue;
                }
                _player.AdditionalInfo["Position"] = positions[position];
                break;
            }
            else
            {
                System.Console.WriteLine("Thats not a integer, try again: ");
            }
        }
        while (true)
        {
            System.Console.Write("Awards: ");
            if(int.TryParse(System.Console.ReadLine(), out int temp))
            {
                _player.AdditionalInfo["Awards"] = temp.ToString();
                break;
            }
            else 
            {
                System.Console.WriteLine("This player doesn't have any awards, right? (y/n)");
                bool check = System.Console.ReadLine() == "y" ? true : false;
                if(check)
                {
                    _player.AdditionalInfo["Awards"] = "not mentioned";
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

/*
Number 1: the goalkeeper.
Numbers 2 and 3: full-backs.
Numbers 4 and 5: The "centre-back" and "sweeper"
Numbers 6 and 7: defensive midfielders.
Numbers 8 and 10: attacking midfielders.
Number 11: the second striker.
Number 9: the centre-forward.
Numbers 12, 13 and 14: the substitutes
*/