using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MtgMeta.Migrations
{
    /// <inheritdoc />
    public partial class unaltra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaMazzo_Carte_CarteNome",
                table: "CartaMazzo");

            migrationBuilder.RenameColumn(
                name: "CarteNome",
                table: "CartaMazzo",
                newName: "carteNome");

            migrationBuilder.AddForeignKey(
                name: "FK_CartaMazzo_Carte_carteNome",
                table: "CartaMazzo",
                column: "carteNome",
                principalTable: "Carte",
                principalColumn: "Nome",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaMazzo_Carte_carteNome",
                table: "CartaMazzo");

            migrationBuilder.RenameColumn(
                name: "carteNome",
                table: "CartaMazzo",
                newName: "CarteNome");

            migrationBuilder.AddForeignKey(
                name: "FK_CartaMazzo_Carte_CarteNome",
                table: "CartaMazzo",
                column: "CarteNome",
                principalTable: "Carte",
                principalColumn: "Nome",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
