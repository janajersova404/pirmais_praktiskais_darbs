using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pirmais_praktiskais_darbs.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nosaukums = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nosaukums = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Darbinieki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzvards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmatsId = table.Column<int>(type: "int", nullable: false),
                    DepartamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Darbinieki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Darbinieki_Amati_AmatsId",
                        column: x => x.AmatsId,
                        principalTable: "Amati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Darbinieki_Departamenti_DepartamentsId",
                        column: x => x.DepartamentsId,
                        principalTable: "Departamenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Darbinieki_AmatsId",
                table: "Darbinieki",
                column: "AmatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Darbinieki_DepartamentsId",
                table: "Darbinieki",
                column: "DepartamentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Darbinieki");

            migrationBuilder.DropTable(
                name: "Amati");

            migrationBuilder.DropTable(
                name: "Departamenti");
        }
    }
}
