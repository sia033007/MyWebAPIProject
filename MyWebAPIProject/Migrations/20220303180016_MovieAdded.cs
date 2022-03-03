using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPIProject.Migrations
{
    public partial class MovieAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Crime" },
                    { 3, "Thriller" },
                    { 4, "War" },
                    { 5, "Action" },
                    { 6, "Fantasy" },
                    { 7, "Horror" },
                    { 8, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Quentine Tarantino", "Pulp Fiction", new DateTime(2022, 3, 3, 21, 30, 14, 696, DateTimeKind.Local).AddTicks(9947) },
                    { 2, "Martin Scorsese", "Taxi Driver", new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999) },
                    { 3, "Michael Jackson", "Hobbit", new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999) },
                    { 4, "Mel Gibson", "1917", new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999) },
                    { 5, "James Wan", "Conjuring", new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999) },
                    { 6, "Alfred Hitchcuck", "Rear Window", new DateTime(2022, 3, 3, 21, 30, 14, 786, DateTimeKind.Local).AddTicks(9999) }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 6, 3 },
                    { 8, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 7, 5 },
                    { 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
