using System.ComponentModel.DataAnnotations.Schema;

class Player
{
    public int PlayerId {get; set;}
    public int TeamId {get; set;}
    public string FullName {get;set;}
    public string Citizenship {get;set;}
    public string OriginCountry {get;set;}
    public DateOnly DateOfBirth {get; set;}
    public Sport Sport {get; set;}
    
    [NotMapped]
    public Dictionary<string, string>? AdditionalInfo {get; set;}
    public Player(
        int playerId, int teamId, string fullName, string citizenship, 
        string originCountry, DateOnly dateOfBirth, Sport sport)
    {
        PlayerId = playerId;
        TeamId = teamId;
        FullName = fullName;
        Citizenship = citizenship;
        OriginCountry = originCountry;
        DateOfBirth = dateOfBirth;
        Sport = sport;
        AdditionalInfo = sport == Sport.Football ? 
        new(){
            {"Awards","0"},
            {"Position","not mentioned"},
            {"Goals","0"}
        } : 
        new(){
            {"All-Star","0"},
            {"Assists","0"},
            {"Rebounds","0"}
        };
    }
}