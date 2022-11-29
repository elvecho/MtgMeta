using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MtgMeta.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lista",
                table: "Mazzi");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mazzi",
                newName: "MazzoId");

            migrationBuilder.CreateTable(
                name: "Carte",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Prezzo = table.Column<int>(type: "INTEGER", nullable: false),
                    MazzoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carte", x => x.Nome);
                    table.ForeignKey(
                        name: "FK_Carte_Mazzi_MazzoId",
                        column: x => x.MazzoId,
                        principalTable: "Mazzi",
                        principalColumn: "MazzoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carte_MazzoId",
                table: "Carte",
                column: "MazzoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carte");

            migrationBuilder.RenameColumn(
                name: "MazzoId",
                table: "Mazzi",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "lista",
                table: "Mazzi",
                type: "TEXT",
                nullable: true);
        }
    }
}
