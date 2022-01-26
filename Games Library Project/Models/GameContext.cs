using Microsoft.EntityFrameworkCore;
namespace Games_Library_Project.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> opt) : base(opt)
        { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = "Ac",
                    Name = "Action"

                },
                new Genre
                {
                    GenreId = "Ad",
                    Name = "Adventure"

                },
                new Genre
                {
                    GenreId = "Pu",
                    Name = "Puzzle"

                }
            );
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    PublisherId = 1,
                    Name = "Microsoft",
                    Year = 1983

                },
                new Publisher
                {
                    PublisherId = 2,
                    Name = "Valve",
                    Year = 1996

                },
                new Publisher
                {
                    PublisherId = 3,
                    Name = "EA",
                    Year = 1983

                }
            );
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    Name = "Tetris",
                    PublisherId = 1,
                    Year = 1984,
                    GenreId = "Pu"
                },
                new Game
                {
                    GameId = 2,
                    Name = "Half-Life",
                    PublisherId = 2,
                    Year = 1998,
                    GenreId = "Ac"
                },
                new Game
                {
                    GameId = 3,
                    Name = "Unravel",
                    PublisherId = 3,
                    Year = 2016,
                    GenreId = "Ad"
                },
                new Game
                {
                    GameId = 4,
                    Name = "CS:GO",
                    PublisherId = 2,
                    Year = 2012,
                    GenreId = "Ac"
                }
            );
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
        }
    }
}
