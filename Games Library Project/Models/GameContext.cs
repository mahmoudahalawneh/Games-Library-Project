namespace Games_Library_Project.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> opt) : base(opt)
        { }
        public DbSet<Game> Games { get; set; }
    }
}
