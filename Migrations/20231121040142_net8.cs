using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSphere.Migrations
{
    /// <inheritdoc />
    public partial class net8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bounties_Difficulties_DifficultyId",
                table: "Bounties");

            migrationBuilder.DropForeignKey(
                name: "FK_Bounties_Statuses_StatusId",
                table: "Bounties");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Bounties_DifficultyId",
                table: "Bounties");

            migrationBuilder.DropIndex(
                name: "IX_Bounties_StatusId",
                table: "Bounties");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Bounties");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Bounties");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Bounties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bounties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Bounties");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bounties");

            migrationBuilder.AddColumn<string>(
                name: "DifficultyId",
                table: "Bounties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "Bounties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    DifficultyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.DifficultyId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Name" },
                values: new object[,]
                {
                    { "average", "Average" },
                    { "easy", "Easy" },
                    { "hard", "Hard" },
                    { "legendary", "Legendary" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "closed", "Completed" },
                    { "open", "Open" },
                    { "pending", "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bounties_DifficultyId",
                table: "Bounties",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bounties_StatusId",
                table: "Bounties",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bounties_Difficulties_DifficultyId",
                table: "Bounties",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "DifficultyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bounties_Statuses_StatusId",
                table: "Bounties",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
