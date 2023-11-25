public sealed class UserInterface
{
    private UserInterface() { }

    private static UserInterface? _interface;

    public static UserInterface GetInstance()
    {
        if (_interface == null)
        {
            _interface = new UserInterface();
        }
        return _interface;
    }
    internal void StartProgram(FanDatabase db)
    {
        TeamRepository teamRepository = new TeamRepository(db);
        PlayerRepository playerRepository = new PlayerRepository(db);
        System.Console.WriteLine(string.Join(" ", playerRepository.GetPlayers()));
        teamRepository += new Team (4, "test", new DateOnly(2022, 1, 1));

        Player damn = new Player(1, 1, "Damn", "Ukraine", "Ukraine", new DateOnly(2000, 1, 4), Sport.Football);

        for (int i = 1; i <= 15; i++)
        {
            Player player = new Player(
                i,
                ((Func<int>)(() =>
                {
                    if (i <= 5)
                        return 1;
                    if (i <= 10)
                        return 2;
                    return 3;
                }
                )).Invoke(),
                $"Player{i}",
                i % 2 == 0 ? "Ukraine" : "Poland",
                i % 2 == 0 ? "Ukraine" : "Poland",
                new DateOnly(1990, 1, i % 28 + 1),
                i % 2 == 0 ? Sport.Football : Sport.Basketball
            );
            playerRepository += player;
        }
        FootballPlayerWorker fWorker = new FootballPlayerWorker(damn);

        while (true)
        {
            System.Console.WriteLine("Welcome to Fanbook! You have next options:\n" +
            "1 - Check list of teams\n" +
            "2 - Check list of Players of concrete team (by team Id)\n" +
            "3 - Check full info about team (by team Id)\n" +
            "4 - Check brief info about team (by team Id)\n\n" +
            "5 - Check full info about player (by player Id)\n" +
            "6 - Check brief info about player (by player Id)\n\n" +
            "7 - Check full info about match (by match Id)\n\n" +
            "8 - Find player by sport/name/team \n\n" +
            "9 - Add new Team \n" +
            "10 - Add Player to Team (by id) \n\n" +
            "11 - Remove Team (by id) \n" +
            "12 - Remove Player (by id) \n\n" +
            "13 - exit\n"
            );
            string? choise = System.Console.ReadLine();

            if (choise == "1")
            {
                System.Console.WriteLine(string.Join("\n", teamRepository.GetTeams()
                                .Select(t => $"id:{t.TeamId}; {t.TeamName}")));
            }

            else if (choise == "2" || choise == "3" || choise == "4")
            {
                System.Console.WriteLine("Enter a team id: ");
                if (int.TryParse(System.Console.ReadLine(), out int teamId))
                {
                    Team? team = db.Teams.Find(teamId);
                    if (team is null)
                    {
                        System.Console.WriteLine($"team with id {teamId} does not exist");
                    }
                    else
                    {
                        switch (choise)
                        {
                            case "2":
                                System.Console.WriteLine(string.Join("\n", team.Players!
                                    .Select(p => new PlayerWorker(p).GetBriefInfo())));
                                break;
                            case "3":
                                System.Console.WriteLine(teamRepository.GetGeneralInfo(teamId));
                                break;
                            case "4":
                                System.Console.WriteLine(new TeamWorker(team).GetBriefInfo());
                                break;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Incorrect team id.");
                }
            }
            else if (choise == "5" || choise == "6")
            {
                System.Console.WriteLine("Enter a player id: ");
                if (int.TryParse(System.Console.ReadLine(), out int playerId))
                {
                    Player? player = db.Players.Find(playerId);
                    if (player is null)
                    {
                        System.Console.WriteLine($"team with id {playerId} does not exist");
                        continue;
                    }
                    switch (choise)
                    {
                        case "5":
                            if (player.Sport == Sport.Football)
                                System.Console.WriteLine(new FootballPlayerWorker(player).GetFullInfo(db));
                            else
                                System.Console.WriteLine(new BasketballPlayerWorker(player).GetFullInfo(db));
                            System.Console.WriteLine(
                                "Enter - return to menu\n" +
                                "1 - change additional info (by key)\n" +
                                "2 - fill additional info");

                            string? nextChoise = System.Console.ReadLine();
                            if (nextChoise == "1")
                            {
                                System.Console.WriteLine("Enter a key: ");
                                string? key = System.Console.ReadLine();

                                System.Console.WriteLine("Enter a value: ");
                                string? value = System.Console.ReadLine();

                                if (key is not null && value is not null)
                                {
                                    new PlayerWorker(player).ChangeAdditionalInfo(key, value);
                                }
                            }
                            else if (nextChoise == "2")
                            {
                                if (player.Sport == Sport.Football)
                                    new FootballPlayerWorker(player).FillAdditionalInfo();
                                else
                                    new BasketballPlayerWorker(player).FillAdditionalInfo();
                            }
                            break;
                        case "6":
                            System.Console.WriteLine(new PlayerWorker(player).GetBriefInfo());
                            break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Incorrect team id.");
                }
            }
            else if (choise == "7")
            {
                System.Console.WriteLine("Enter a Match id: ");
                if (int.TryParse(System.Console.ReadLine(), out int matchId))
                {
                    Match? match = db.Matches.Find(matchId);
                    if (match is null)
                    {
                        System.Console.WriteLine($"team with id {matchId} does not exist");
                        System.Console.Write($"(Enter to continue)");
                        System.Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        System.Console.WriteLine(new MatchWorker(match).GetFullInfo(db));
                    }
                }
                else
                {
                    System.Console.WriteLine("Incorrect match id.");
                }
            }
            else if (choise == "8")
            {
                System.Console.WriteLine("What information do you want to provide?");
                System.Console.WriteLine(
                    "1 - Sport;\n" +
                    "2 - Name (part of name);\n" +
                    "3 - Team name."
                );
                if (int.TryParse(System.Console.ReadLine(), out int choosenInfo))
                {
                    switch (choosenInfo)
                    {
                        case 1:
                            System.Console.WriteLine("Select a sport:");
                            System.Console.WriteLine(
                                "1 - Football" +
                                "2 - Basketball");
                            if (int.TryParse(System.Console.ReadLine(), out int choosenSport))
                            {
                                if (choosenSport != 1 || choosenSport != 2)
                                {
                                    System.Console.WriteLine("Error! thats not a number 1 or 2.");
                                }
                                Sport sportToSelect = choosenSport == 1 ? Sport.Football : Sport.Basketball;

                                System.Console.WriteLine(
                                    string.Join("\n",
                                    playerRepository.GetPlayers().Where(p => p.Sport == sportToSelect)
                                        .Select(p => new PlayerWorker(p).GetBriefInfo())
                                ));

                            }
                            break;
                        case 2:
                            System.Console.WriteLine("Enter a name (or a part of):");
                            string? NameToSelect = System.Console.ReadLine();
                            if (NameToSelect is not null)
                            {
                                System.Console.WriteLine(
                                    string.Join("\n",
                                    playerRepository.GetPlayers()
                                    .Where(p => p.FullName.ToLower().Contains(NameToSelect.ToLower()))
                                        .Select(p => new PlayerWorker(p).GetBriefInfo())
                                ));
                            }
                            else
                            {
                                System.Console.WriteLine("Error! you have not entered any characters.");
                            }
                            break;
                        case 3:
                            System.Console.WriteLine("Enter a team name (or a part of):");
                            string? TeamNameToSelect = System.Console.ReadLine();
                            if (TeamNameToSelect is not null)
                            {
                                System.Console.WriteLine(
                                    string.Join("\n",
                                    teamRepository.GetTeams()
                                    .Where(t => t.TeamName!.ToLower().Contains(TeamNameToSelect.ToLower()))
                                    .Select(t =>
                                    $"Team: {t.TeamName}; team id: {t.TeamId}\n" +
                                    $"Players:\n" +
                                    string.Join("\n", t.Players!.Select(p => new PlayerWorker(p).GetBriefInfo())))
                                    )
                                );
                            }
                            break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Error! thats not a number 1, 2 or 3.");
                }
            }
            else if (choise == "9")
            {
                System.Console.WriteLine("Enter a team name: ");
                string teamName = System.Console.ReadLine();
                System.Console.WriteLine("Enter a date of foundation (format yyyy-MM-dd): ");
                string dateString = System.Console.ReadLine();
                string dateFormat = "yyyy-MM-dd";
                int newTeamId = 0;
                teamRepository.GetTeams().ForEach(t => newTeamId = t.TeamId > newTeamId ? t.TeamId : newTeamId);
                newTeamId++;
                teamRepository.SaveChanges();
                if (DateTime.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                {
                    DateOnly date = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
                    Console.WriteLine($"Parsed date: {date}");
                    teamRepository += new Team(newTeamId, teamName, date);
                    System.Console.WriteLine("new team created successfully");
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                }

            }
            else if (choise == "10")
            {
                System.Console.WriteLine("Enter a team id: ");
                if(int.TryParse(System.Console.ReadLine(), out int teamId))
                {
                    Team findTeam = teamRepository.GetById(teamId);
                    if (findTeam is null)
                    {
                        System.Console.WriteLine("Team with this id does not exist.");
                        break;
                    }
                    System.Console.WriteLine("Enter a player id: ");
                    if(int.TryParse(System.Console.ReadLine(), out int playerId))
                    {
                        Player findPlayer = playerRepository.GetById(playerId);
                        if (findPlayer is null)
                        {
                            System.Console.WriteLine("Player with this id does not exist.");
                            break;
                        }
                        var playerTeam = teamRepository.GetById(findPlayer.TeamId);
                        if(playerTeam is not null)
                        {
                            playerTeam.Players.Remove(findPlayer);
                        }
                        findTeam.Players.Add(findPlayer);
                    }
                    else
                    {
                        System.Console.WriteLine("Please, enter a integer!");
                        break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Please, enter a integer!");
                    break;
                }
            }
            else if (choise == "11")
            {
                System.Console.WriteLine("Write id to remove team");
                if(int.TryParse(System.Console.ReadLine(), out int teamId))
                {
                    teamRepository.RemoveById(teamId);
                }
                else
                {
                    System.Console.WriteLine("Team with this id does not exist");
                }
            }
            else if (choise == "12")
            {
                System.Console.WriteLine("Write id to remove player");
                if(int.TryParse(System.Console.ReadLine(), out int playerId))
                {
                    playerRepository.RemoveById(playerId);
                }
                else
                {
                    System.Console.WriteLine("Player with this id does not exist");
                }
            }
            else if (choise == "13")
                {
                    System.Console.WriteLine("Goodbye!");
                    System.Console.Write($"(Enter to continue)");
                    System.Console.ReadLine();
                    return;
                }
            System.Console.Write($"(Enter to continue)");
            System.Console.ReadLine();
        }
    }
}
