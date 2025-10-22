using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogSimple.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Code", "Date", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "Paula Docampo", "Esta es la primera entrada: practicando MVC y Razor.", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the first post on my blog. Stay tuned for more content!", "Bienvenidos al Blog" },
                    { 2, "Paula Docampo", "Explorando más sobre ASP.NET Core.", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "In this post, we will explore more features of ASP.NET Core.", "Segunda Entrada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
