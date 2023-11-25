using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class FanDatabase : DbContext
{
    public DbSet<Match> Matches {get; set;}
    public DbSet<Team> Teams {get; set;}
    public DbSet<Player> Players {get; set;}
    public FanDatabase(DbContextOptions options):base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Team Kolobky = new Team(1, "Kolobky", new DateOnly(2000,1,4));
        Team Bandery = new Team(2, "Bandery", new DateOnly(1992,12,2));
        Team Zmiyi = new Team(3, "Zmiyi", new DateOnly(2010,10,7));
        
        List<Match> matches = new List<Match>
        {
            new Match (1,"USA",new DateOnly(2023, 5, 1), (2, 1), 1, 2 ),
            new Match (2,"Germany",new DateOnly(2023, 5, 2), (3, 0), 2, 1 ),
            new Match (3,"France",new DateOnly(2023, 5, 3), (1, 1), 1, 2 ),
            new Match (4,"Brazil",new DateOnly(2023, 5, 4), (2, 2), 1, 2 ),
            new Match (5,"Spain",new DateOnly(2023, 5, 5), (0, 1), 1, 2 ),
            new Match (6,"Italy",new DateOnly(2023, 5, 6), (2, 0), 2, 3 )
        };
        List<Team> teams = new List<Team>{Kolobky, Bandery, Zmiyi};
        
        modelBuilder.Entity<Team>().HasData(teams);
        modelBuilder.Entity<Match>().HasData(matches);
        
        
        base.OnModelCreating(modelBuilder);
    }
}