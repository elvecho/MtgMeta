using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MtgMeta.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carte",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Prezzo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carte", x => x.Nome);
                });

            migrationBuilder.CreateTable(
                name: "Mazzi",
                columns: table => new
                {
                    MazzoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PercentualeMeta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mazzi", x => x.MazzoId);
                });

            migrationBuilder.CreateTable(
                name: "CartaMazzo",
                columns: table => new
                {
                    carteNome = table.Column<string>(type: "TEXT", nullable: false),
                    mazziMazzoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaMazzo", x => new { x.carteNome, x.mazziMazzoId });
                    table.ForeignKey(
                        name: "FK_CartaMazzo_Carte_carteNome",
                        column: x => x.carteNome,
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

            migrationBuilder.DropTable(
                name: "Carte");

            migrationBuilder.DropTable(
                name: "Mazzi");
        }
    }
}
