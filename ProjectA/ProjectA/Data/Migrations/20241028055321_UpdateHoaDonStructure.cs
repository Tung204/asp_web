using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectA.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHoaDonStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "HoaDon",
                newName: "Ward");

            migrationBuilder.AddColumn<string>(
                name: "DetailedAddress",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedAddress",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "District",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "HoaDon");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "HoaDon",
                newName: "Address");
        }
    }
}
