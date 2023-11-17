using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica02Backend.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Niveles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nivelNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasatiempos",
                columns: table => new
                {
                    perfilId = table.Column<int>(type: "int", nullable: false),
                    pasatiempo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasatiempos", x => new { x.perfilId, x.pasatiempo });
                    table.ForeignKey(
                        name: "FK_Pasatiempos_Perfiles_perfilId",
                        column: x => x.perfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilFrameworks",
                columns: table => new
                {
                    perfilId = table.Column<int>(type: "int", nullable: false),
                    framework = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nivelId = table.Column<int>(type: "int", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilFrameworks", x => new { x.perfilId, x.framework });
                    table.ForeignKey(
                        name: "FK_PerfilFrameworks_Perfiles_perfilId",
                        column: x => x.perfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Niveles");

            migrationBuilder.DropTable(
                name: "Pasatiempos");

            migrationBuilder.DropTable(
                name: "PerfilFrameworks");

            migrationBuilder.DropTable(
                name: "Perfiles");
        }
    }
}
