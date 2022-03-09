using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPIProject.Migrations
{
    public partial class SeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Brad Pitt" },
                    { 10, "Sam Worthington" },
                    { 9, "Arnold Schwartzeneger" },
                    { 8, "Hugh Jackman" },
                    { 7, "Robert De Niro" },
                    { 11, "Kurt Russell" },
                    { 5, "Martin Freeman" },
                    { 4, "Christoph Waltz" },
                    { 3, "Matthew McConaughy" },
                    { 2, "Leonardo Di Caprio" },
                    { 6, "Ian McKellen" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan" },
                    { 2, "Quentine Tarantino" },
                    { 3, "Martin Scorsese" },
                    { 4, "James Cameron" },
                    { 5, "Michael Jackson" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Action" },
                    { 1, "Crime" },
                    { 2, "Adventure" },
                    { 3, "Fantasy" },
                    { 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 6, 1, "Interstellar", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 7, 1, "Prestige", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 8, 1, "Inception", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 3, 2, "Hateful Eight", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 4, 2, "Inglorious Bastards", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 5, 2, "Django Unchained", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 11, 3, "The Wolf of Wall Street", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 12, 3, "Taxi Driver", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 1, 4, "Avatar", new DateTime(2022, 3, 4, 20, 16, 56, 523, DateTimeKind.Local).AddTicks(7365) },
                    { 2, 4, "Terminator", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 9, 5, "The Lord of the Rings", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) },
                    { 10, 5, "The Hobbit", new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
