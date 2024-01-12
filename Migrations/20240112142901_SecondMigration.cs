using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ccse_cw1.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "754857bb-490b-4ad3-94c4-487c4b0a6261", null, "admin", "admin" },
                    { "e1aaed65-b0f2-4846-b0d1-c426eed4409b", null, "client", "client" },
                    { "f066774b-65d5-46b1-b6a8-85eb422fcbd8", null, "seller", "seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "754857bb-490b-4ad3-94c4-487c4b0a6261");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1aaed65-b0f2-4846-b0d1-c426eed4409b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f066774b-65d5-46b1-b6a8-85eb422fcbd8");
        }
    }
}
