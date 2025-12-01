using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineMontecasteloMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Peliculas_PeliculaId",
                table: "Salas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Peliculas",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "PeliculaEditViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaEditViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaCheckboxViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asignada = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeliculaEditViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaCheckboxViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaCheckboxViewModel_PeliculaEditViewModel_PeliculaEditViewModelId",
                        column: x => x.PeliculaEditViewModelId,
                        principalTable: "PeliculaEditViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "NombreUsuario", "PasswordHash" },
                values: new object[] { 1, "admin", "100000.hiZiCsDch3ZBoZOrt+jH2w==.9J8zFXeNof73L5Qf9ya2E1XH+mXOM9dsowCyncZKwVI=" });

            migrationBuilder.CreateIndex(
                name: "IX_SalaCheckboxViewModel_PeliculaEditViewModelId",
                table: "SalaCheckboxViewModel",
                column: "PeliculaEditViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Peliculas_PeliculaId",
                table: "Salas",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Peliculas_PeliculaId",
                table: "Salas");

            migrationBuilder.DropTable(
                name: "SalaCheckboxViewModel");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "PeliculaEditViewModel");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Peliculas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6,
                oldScale: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Peliculas_PeliculaId",
                table: "Salas",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id");
        }
    }
}
