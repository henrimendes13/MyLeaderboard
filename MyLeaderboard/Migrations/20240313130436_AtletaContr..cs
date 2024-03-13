using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLeaderboard.Migrations
{
    /// <inheritdoc />
    public partial class AtletaContr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atleta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Score1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleta", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atleta");
        }
    }
}
