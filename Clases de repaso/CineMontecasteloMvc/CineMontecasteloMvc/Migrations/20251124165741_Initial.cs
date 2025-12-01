using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CineMontecasteloMvc.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FotoMimeType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aforo = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salas_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Id", "Anio", "Descripcion", "Duracion", "Foto", "FotoMimeType", "Genero", "Precio", "Titulo" },
                values: new object[,]
                {
                    { 1, 2024, "Las emociones vuelven con nuevas aventuras.", 110, null, null, "Animación", 9.50m, "Inside Out 2" },
                    { 2, 2024, "Paul Atreides y los Fremen en Arrakis.", 165, null, null, "Ciencia ficción", 9.00m, "Dune:Parte Dos" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Id", "Aforo", "Nombre", "PeliculaId" },
                values: new object[,]
                {
                    { 3, 80, "Sala 3", null },
                    { 1, 150, "Sala 1", 1 },
                    { 2, 100, "Sala 2", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salas_PeliculaId",
                table: "Salas",
                column: "PeliculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}
