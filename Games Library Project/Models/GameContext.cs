using Microsoft.EntityFrameworkCore;
namespace Games_Library_Project.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> opt) : base(opt)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Mahmoud", Password = "Admin" },
                new User { UserId = 2, UserName = "AAA", Password = "123" },
                new User { UserId = 3, UserName = "F2P", Password = "321" }
                );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { UserId = 1, GenreId = "10Ac", Name = "Action"},
                new Genre { UserId = 1, GenreId = "10Ad", Name = "Adventure"},
                new Genre { UserId = 1, GenreId = "10Pu", Name = "Puzzle"},
                new Genre { UserId = 2, GenreId = "20Ro", Name = "Role-Playing" },
                new Genre { UserId = 2, GenreId = "20FP", Name = "FPS" },
                new Genre { UserId = 2, GenreId = "20So", Name = "Social simulation" },
                new Genre { UserId = 2, GenreId = "20Ha", Name = "Hack N Slash" },
                new Genre { UserId = 3, GenreId = "30RP", Name = "RPG" },
                new Genre { UserId = 3, GenreId = "30FP", Name = "FPS" },
                new Genre { UserId = 3, GenreId = "30MM", Name = "MMORPG" }
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { UserId = 1, PublisherId = 1, Name = "Microsoft", Year = 1983},
                new Publisher { UserId = 1, PublisherId = 2, Name = "Valve", Year = 1996},
                new Publisher { UserId = 1, PublisherId = 3, Name = "EA", Year = 1983},
                new Publisher { UserId = 2, PublisherId = 4, Name = "CD PROJEKT RED", Year = 2020 },
                new Publisher { UserId = 2, PublisherId = 5, Name = "Bethesda Softworks", Year = 1986 },
                new Publisher { UserId = 2, PublisherId = 6, Name = "Nintendo", Year = 1889 },
                new Publisher { UserId = 2, PublisherId = 7, Name = "Sony Interactive Entertainment", Year = 1993 },
                new Publisher { UserId = 3, PublisherId = 8, Name = "miHoYo", Year = 2012 },
                new Publisher { UserId = 3, PublisherId = 9, Name = "Hi Rez Studios", Year = 2005 }
                );

            modelBuilder.Entity<Game>().HasData(
                new Game { UserId = 1, GameId = 1, Name = "Tetris", PublisherId = 1, Year = 1984, GenreId = "10Pu", Available = "All", Price = "Free", StoreLink = "https://tetris.com/play-tetris", ImgLink = "https://cdn.vox-cdn.com/thumbor/6Wng0B6dz6T2qkPcOdwm-3vuvYg=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/14257423/Switch_Tetris99_ND0213_SCRN_03.jpg" },
                new Game { UserId = 1, GameId = 2, Name = "Half-Life", PublisherId = 2, Year = 1998, GenreId = "10Ac", Available = "All", Price = "$9.99", StoreLink = "https://store.steampowered.com/app/70/HalfLife/", ImgLink = "https://cdn.cloudflare.steamstatic.com/steam/apps/70/capsule_616x353.jpg?t=1591048039" },
                new Game { UserId = 1, GameId = 3, Name = "Unravel", PublisherId = 3, Year = 2016, GenreId = "10Ad", Available = "All", Price = "$19.99", StoreLink = "https://www.ea.com/en-gb/games/unravel", ImgLink = "https://media.contentapi.ea.com/content/dam/eacom/unravel/ea-hero-large-unravel-xl.jpg.adapt.crop16x9.575p.jpg" },
                new Game { UserId = 1, GameId = 4, Name = "CS:GO", PublisherId = 2, Year = 2012, GenreId = "10Ac", Available = "All", Price = "Free", StoreLink = "https://store.steampowered.com/app/730/CounterStrike_Global_Offensive/", ImgLink = "https://quoramarketing.com/wp-content/uploads/2021/05/Fix-CSGO-Download-Incomplete-Replay-Error.jpg" },
                new Game { UserId = 2, GameId = 5, Name = "Cyberpunk 2077", PublisherId = 4, Year = 2020, GenreId = "20Ro", Available = "All", Price = "$59.99", StoreLink = "https://store.steampowered.com/app/1091500/Cyberpunk_2077/?snr=1_550_553__1009", ImgLink = "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/header.jpg?t=1621944801" },
                new Game { UserId = 2, GameId = 6, Name = "DOOM Eternal", PublisherId = 5, Year = 2020, GenreId = "20FP", Available = "All", Price = "$19.99", StoreLink = "https://store.steampowered.com/app/782330/DOOM_Eternal/", ImgLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqe2y9fgNzrBGERVxiYXqPV19sXlAOAq_mS61JGMAIqtAbv0NktCbAUf6CZ1XhFNewGzA&usqp=CAU" },
                new Game { UserId = 2, GameId = 7, Name = "Animal Crossing: New Horizons", PublisherId = 6, Year = 2020, GenreId = "20So", Available = "Switch", Price = "$59.99", StoreLink = "https://store.steampowered.com/app/782330/DOOM_Eternal/", ImgLink = "https://i.ytimg.com/vi/qK8qe7O0OM8/maxresdefault.jpg" },
                new Game { UserId = 2, GameId = 8, Name = "God of War", PublisherId = 7, Year = 2018, GenreId = "20Ha", Available = "Playstation", Price = "$19.99", StoreLink = "https://www.playstation.com/en-us/games/god-of-war/", ImgLink = "https://cdn1.epicgames.com/offer/3ddd6a590da64e3686042d108968a6b2/EGS_GodofWar_SantaMonicaStudio_S1_2560x1440-5d74d9b240bba8f2c40920dcde7c5c67_2560x1440-5d74d9b240bba8f2c40920dcde7c5c67" },
                new Game { UserId = 3, GameId = 9, Name = "Genshin Impact", PublisherId = 8, Year = 2020, GenreId = "30RP", Available = "All", Price = "Free", StoreLink = "https://genshin.mihoyo.com/en/", ImgLink = "https://www.ginx.tv/uploads2/Genshin_Impact/GenshinBombing_inside_1.jpeg?ezimgfmt=ng%3Awebp%2Fngcb5%2Frs%3Adevice%2Frscb5-2" },
                new Game { UserId = 3, GameId = 10, Name = "Paladins", PublisherId = 9, Year = 2016, GenreId = "30FP", Available = "PC", Price = "Free", StoreLink = "https://www.paladins.com/", ImgLink = "https://cdn.cloudflare.steamstatic.com/steam/apps/444090/header.jpg?t=1643214144" },
                new Game { UserId = 3, GameId = 11, Name = "Smite", PublisherId = 9, Year = 2014, GenreId = "30MM", Available = "All", Price = "Free", StoreLink = "https://www.smitegame.com/", ImgLink = "https://cdnb.artstation.com/p/assets/covers/images/043/597/157/large/daniel-wee-daniel-wee-6.jpg?1637719403" }
                );

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Game>().ToTable("Game");
        }
    }
}
