using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMVCProject.Migrations
{
    public partial class PlayerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    playerId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    playerPosition = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    playerNationality = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.playerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
