using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SetValueTryPropsToCarsTableTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BigImageUrl", "BrandId", "CoverImageUrl", "Fuel", "Km", "Luggage", "Model", "Seat", "Transmission" },
                values: new object[,]
                {
                    { 1, "asdasdasd", 1, "asdasdasd", "asdasdasd", 44, 25, "asdasdasd", 42, "asdasdasdad" },
                    { 2, "astra", 1, "asdasdasd", "asdasdasd", 15, 65, "asdasdasd", 52, "asdasdasdad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
