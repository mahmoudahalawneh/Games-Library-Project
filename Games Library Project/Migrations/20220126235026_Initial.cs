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
                    Available = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "GameId", "Available", "GenreId", "Name", "PublisherId", "Year" },
                values: new object[,]
                {
                    { 1, null, "Pu", "Tetris", 1, 1984 },
                    { 2, null, "Ac", "Half-Life", 2, 1998 },
                    { 4, null, "Ac", "CS:GO", 2, 2012 },
                    { 3, null, "Ad", "Unravel", 3, 2016 }
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
