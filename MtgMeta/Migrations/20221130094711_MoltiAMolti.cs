using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MtgMeta.Migrations
{
    /// <inheritdoc />
    public partial class MoltiAMolti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carte_Mazzi_MazzoId",
                table: "Carte");

            migrationBuilder.DropIndex(
                name: "IX_Carte_MazzoId",
                table: "Carte");

            migrationBuilder.RenameColumn(
                name: "MazzoId",
                table: "Carte",
                newName: "Numero");

            migrationBuilder.CreateTable(
                name: "CartaMazzo",
                columns: table => new
                {
                    CarteNome = table.Column<string>(type: "TEXT", nullable: false),
                    mazziMazzoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaMazzo", x => new { x.CarteNome, x.mazziMazzoId });
                    table.ForeignKey(
                        name: "FK_CartaMazzo_Carte_CarteNome",
                        column: x => x.CarteNome,
                        principalTable: "Carte",
                        principalColumn: "Nome",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartaMazzo_Mazzi_mazziMazzoId",
                        column: x => x.mazziMazzoId,
                        principalTable: "Mazzi",
                        principalColumn: "MazzoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaMazzo_mazziMazzoId",
                table: "CartaMazzo",
                column: "mazziMazzoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartaMazzo");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Carte",
                newName: "MazzoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carte_MazzoId",
                table: "Carte",
                column: "MazzoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carte_Mazzi_MazzoId",
                table: "Carte",
                column: "MazzoId",
                principalTable: "Mazzi",
                principalColumn: "MazzoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
