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
                new Genre { GenreId = "Ac", Name = "Action"},
                new Genre { GenreId = "Ad", Name = "Adventure"},
                new Genre { GenreId = "Pu", Name = "Puzzle"});

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, Name = "Microsoft", Year = 1983},
                new Publisher { PublisherId = 2, Name = "Valve", Year = 1996},
                new Publisher { PublisherId = 3, Name = "EA", Year = 1983});

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = 1, Name = "Tetris", PublisherId = 1, Year = 1984, GenreId = "Pu", Available = "All", Price = "Free", StoreLink = "https://tetris.com/play-tetris", ImgLink = "https://cdn.vox-cdn.com/thumbor/6Wng0B6dz6T2qkPcOdwm-3vuvYg=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/14257423/Switch_Tetris99_ND0213_SCRN_03.jpg" },
                new Game { GameId = 2, Name = "Half-Life", PublisherId = 2, Year = 1998, GenreId = "Ac", Available = "All", Price = "9.99$", StoreLink = "https://store.steampowered.com/app/70/HalfLife/", ImgLink = "https://cdn.cloudflare.steamstatic.com/steam/apps/70/capsule_616x353.jpg?t=1591048039" },
                new Game { GameId = 3, Name = "Unravel", PublisherId = 3, Year = 2016, GenreId = "Ad", Available = "All", Price = "19.99$", StoreLink = "https://www.ea.com/en-gb/games/unravel", ImgLink = "https://media.contentapi.ea.com/content/dam/eacom/unravel/ea-hero-large-unravel-xl.jpg.adapt.crop16x9.575p.jpg" },
                new Game { GameId = 4, Name = "CS:GO", PublisherId = 2, Year = 2012, GenreId = "Ac", Available = "All", Price = "Free", StoreLink = "https://store.steampowered.com/app/730/CounterStrike_Global_Offensive/", ImgLink = "https://quoramarketing.com/wp-content/uploads/2021/05/Fix-CSGO-Download-Incomplete-Replay-Error.jpg" });

            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
        }
    }
}
