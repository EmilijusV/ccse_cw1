using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ccse_cw1.Migrations.BookingSystemMigrations
{
    /// <inheritdoc />
    public partial class PackageTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Packages",
                newName: "TourStartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Packages",
                newName: "TourEndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "HotelEndDate",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HotelStartDate",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelEndDate",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "HotelStartDate",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "TourStartDate",
                table: "Packages",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "TourEndDate",
                table: "Packages",
                newName: "EndDate");
        }
    }
}
