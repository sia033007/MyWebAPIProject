using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPIProject.Migrations
{
    public partial class NewDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "Tom Hanks" },
                    { 13, "Samuel L.Jackson" },
                    { 14, "Morgan Freeman" },
                    { 15, "Al Pacino" },
                    { 16, "Edward Norton" }
                });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Peter Jackson");

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Ford Coppolla" },
                    { 8, "Frank Darabont" },
                    { 9, "David Fincher" },
                    { 6, "Steven Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Animation" },
                    { 7, "Drama" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 363, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 13, 6, "Schindler's List", new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860) },
                    { 14, 6, "Adventures of Tin Tin", new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860) },
                    { 15, 7, "Godfather", new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860) },
                    { 16, 8, "Green Mile", new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860) },
                    { 17, 8, "Shawshank Redemption", new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860) },
                    { 18, 9, "Se7en", new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860) },
                    { 19, 9, "Fight Club", new DateTime(2022, 3, 5, 18, 31, 9, 370, DateTimeKind.Local).AddTicks(4860) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Michael Jackson");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 523, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "ReleaseDate",
                value: new DateTime(2022, 3, 4, 20, 16, 56, 533, DateTimeKind.Local).AddTicks(7371));
        }
    }
}
