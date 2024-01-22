using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ccse_cw1.Migrations.BookingSystemMigrations
{
    /// <inheritdoc />
    public partial class PackageTableUpdatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Packages_HotelID",
                table: "Packages",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TourID",
                table: "Packages",
                column: "TourID");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Hotels_HotelID",
                table: "Packages",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Tours_TourID",
                table: "Packages",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "TourID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Hotels_HotelID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Tours_TourID",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_HotelID",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_TourID",
                table: "Packages");
        }
    }
}
