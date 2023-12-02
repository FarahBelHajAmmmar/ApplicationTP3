using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationTP3_second_.Migrations
{
    /// <inheritdoc />
    public partial class initialone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Genrename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membershiptypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signupfee = table.Column<float>(type: "real", nullable: false),
                    DurationInMonth = table.Column<float>(type: "real", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membershiptypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genres_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_genres_Id",
                        column: x => x.genres_Id,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershiptypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Membershiptypes_MembershiptypesId",
                        column: x => x.MembershiptypesId,
                        principalTable: "Membershiptypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomersMovies",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersMovies", x => new { x.CustomersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CustomersMovies_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersMovies_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Genrename" },
                values: new object[,]
                {
                    { "79e6f638-d7e7-4f63-8365-f172cb925381", null },
                    { "84ca0bcd-082c-49cb-aa77-ea2f1f5f8285", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershiptypesId",
                table: "Customers",
                column: "MembershiptypesId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersMovies_MoviesId",
                table: "CustomersMovies",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genres_Id",
                table: "Movies",
                column: "genres_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersMovies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Membershiptypes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
