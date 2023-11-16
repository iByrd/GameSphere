using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSphere.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bounties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reward = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bounties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bounties",
                columns: new[] { "Id", "Description", "Name", "Reward" },
                values: new object[] { 1, "Old man planning to take over the world!", "Dr.Evil", 150m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bounties");
        }
    }
}
