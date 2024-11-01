using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectA.Data.Migrations
{
    /// <inheritdoc />
    public partial class sanpham2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_2",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_3",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_4",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_2",
                table: "BoSuuTap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_3",
                table: "BoSuuTap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_4",
                table: "BoSuuTap",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl_2",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ImageUrl_3",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ImageUrl_4",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ImageUrl_2",
                table: "BoSuuTap");

            migrationBuilder.DropColumn(
                name: "ImageUrl_3",
                table: "BoSuuTap");

            migrationBuilder.DropColumn(
                name: "ImageUrl_4",
                table: "BoSuuTap");
        }
    }
}
