using Microsoft.EntityFrameworkCore.Migrations;

namespace Games_Library_Project.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Available = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "Ac", "Action" },
                    { "Ad", "Adventure" },
                    { "Pu", "Puzzle" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "PublisherId", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Microsoft", 1983 },
                    { 2, "Valve", 1996 },
                    { 3, "EA", 1983 }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GameId", "Available", "GenreId", "ImgLink", "Name", "Price", "PublisherId", "StoreLink", "Year" },
                values: new object[,]
                {
                    { 1, "All", "Pu", "https://cdn.vox-cdn.com/thumbor/6Wng0B6dz6T2qkPcOdwm-3vuvYg=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/14257423/Switch_Tetris99_ND0213_SCRN_03.jpg", "Tetris", "Free", 1, "https://tetris.com/play-tetris", 1984 },
                    { 2, "All", "Ac", "https://cdn.cloudflare.steamstatic.com/steam/apps/70/capsule_616x353.jpg?t=1591048039", "Half-Life", "9.99$", 2, "https://store.steampowered.com/app/70/HalfLife/", 1998 },
                    { 4, "All", "Ac", "https://quoramarketing.com/wp-content/uploads/2021/05/Fix-CSGO-Download-Incomplete-Replay-Error.jpg", "CS:GO", "Free", 2, "https://store.steampowered.com/app/730/CounterStrike_Global_Offensive/", 2012 },
                    { 3, "All", "Ad", "https://media.contentapi.ea.com/content/dam/eacom/unravel/ea-hero-large-unravel-xl.jpg.adapt.crop16x9.575p.jpg", "Unravel", "19.99$", 3, "https://www.ea.com/en-gb/games/unravel", 2016 }
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
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
