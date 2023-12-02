using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationTP3_second_.Migrations
{
    /// <inheritdoc />
    public partial class secondone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genrename",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "79e6f638-d7e7-4f63-8365-f172cb925381",
                column: "GenreName",
                value: "GenreFromJsonFile2");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "84ca0bcd-082c-49cb-aa77-ea2f1f5f8285",
                column: "GenreName",
                value: "GenreFromJsonFile1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genres",
                newName: "Genrename");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "79e6f638-d7e7-4f63-8365-f172cb925381",
                column: "Genrename",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "84ca0bcd-082c-49cb-aa77-ea2f1f5f8285",
                column: "Genrename",
                value: null);
        }
    }
}
