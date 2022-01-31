using Microsoft.EntityFrameworkCore.Migrations;

namespace Games_Library_Project.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    GenreId = table.Column<string>(nullable: false),
                    Available = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: false),
                    StoreLink = table.Column<string>(nullable: true),
                    ImgLink = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Name", "UserId" },
                values: new object[,]
                {
                    { "10Ac", "Action", 1 },
                    { "10Ad", "Adventure", 1 },
                    { "10Pu", "Puzzle", 1 },
                    { "20Ro", "Role-Playing", 2 },
                    { "20FP", "FPS", 2 },
                    { "20So", "Social simulation", 2 },
                    { "20Ha", "Hack N Slash", 2 },
                    { "30RP", "RPG", 3 },
                    { "30FP", "FPS", 3 },
                    { "30MM", "MMORPG", 3 }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "PublisherId", "Name", "UserId", "Year" },
                values: new object[,]
                {
                    { 9, "Hi Rez Studios", 3, 2005 },
                    { 8, "miHoYo", 3, 2012 },
                    { 7, "Sony Interactive Entertainment", 2, 1993 },
                    { 6, "Nintendo", 2, 1889 },
                    { 1, "Microsoft", 1, 1983 },
                    { 4, "CD PROJEKT RED", 2, 2020 },
                    { 3, "EA", 1, 1983 },
                    { 2, "Valve", 1, 1996 },
                    { 5, "Bethesda Softworks", 2, 1986 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Password", "UserName" },
                values: new object[,]
                {
                    { 2, "123", "AAA" },
                    { 1, "Admin", "Mahmoud" },
                    { 3, "321", "F2P" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GameId", "Available", "GenreId", "ImgLink", "Name", "Price", "PublisherId", "StoreLink", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "All", "10Pu", "https://cdn.vox-cdn.com/thumbor/6Wng0B6dz6T2qkPcOdwm-3vuvYg=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/14257423/Switch_Tetris99_ND0213_SCRN_03.jpg", "Tetris", "Free", 1, "https://tetris.com/play-tetris", 1, 1984 },
                    { 2, "All", "10Ac", "https://cdn.cloudflare.steamstatic.com/steam/apps/70/capsule_616x353.jpg?t=1591048039", "Half-Life", "$9.99", 2, "https://store.steampowered.com/app/70/HalfLife/", 1, 1998 },
                    { 4, "All", "10Ac", "https://quoramarketing.com/wp-content/uploads/2021/05/Fix-CSGO-Download-Incomplete-Replay-Error.jpg", "CS:GO", "Free", 2, "https://store.steampowered.com/app/730/CounterStrike_Global_Offensive/", 1, 2012 },
                    { 3, "All", "10Ad", "https://media.contentapi.ea.com/content/dam/eacom/unravel/ea-hero-large-unravel-xl.jpg.adapt.crop16x9.575p.jpg", "Unravel", "$19.99", 3, "https://www.ea.com/en-gb/games/unravel", 1, 2016 },
                    { 5, "All", "20Ro", "https://cdn.cloudflare.steamstatic.com/steam/apps/1091500/header.jpg?t=1621944801", "Cyberpunk 2077", "$59.99", 4, "https://store.steampowered.com/app/1091500/Cyberpunk_2077/?snr=1_550_553__1009", 2, 2020 },
                    { 6, "All", "20FP", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqe2y9fgNzrBGERVxiYXqPV19sXlAOAq_mS61JGMAIqtAbv0NktCbAUf6CZ1XhFNewGzA&usqp=CAU", "DOOM Eternal", "$19.99", 5, "https://store.steampowered.com/app/782330/DOOM_Eternal/", 2, 2020 },
                    { 7, "Switch", "20So", "https://i.ytimg.com/vi/qK8qe7O0OM8/maxresdefault.jpg", "Animal Crossing: New Horizons", "$59.99", 6, "https://store.steampowered.com/app/782330/DOOM_Eternal/", 2, 2020 },
                    { 8, "Playstation", "20Ha", "https://cdn1.epicgames.com/offer/3ddd6a590da64e3686042d108968a6b2/EGS_GodofWar_SantaMonicaStudio_S1_2560x1440-5d74d9b240bba8f2c40920dcde7c5c67_2560x1440-5d74d9b240bba8f2c40920dcde7c5c67", "God of War", "$19.99", 7, "https://www.playstation.com/en-us/games/god-of-war/", 2, 2018 },
                    { 9, "All", "30RP", "https://www.ginx.tv/uploads2/Genshin_Impact/GenshinBombing_inside_1.jpeg?ezimgfmt=ng%3Awebp%2Fngcb5%2Frs%3Adevice%2Frscb5-2", "Genshin Impact", "Free", 8, "https://genshin.mihoyo.com/en/", 3, 2020 },
                    { 10, "PC", "30FP", "https://cdn.cloudflare.steamstatic.com/steam/apps/444090/header.jpg?t=1643214144", "Paladins", "Free", 9, "https://www.paladins.com/", 3, 2016 },
                    { 11, "All", "30MM", "https://cdnb.artstation.com/p/assets/covers/images/043/597/157/large/daniel-wee-daniel-wee-6.jpg?1637719403", "Smite", "Free", 9, "https://www.smitegame.com/", 3, 2014 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_GenreId",
                table: "Game",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PublisherId",
                table: "Game",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
