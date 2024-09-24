using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiKiemTra02.Data.Migrations
{
    /// <inheritdoc />
    public partial class ue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuongSinhVien",
                table: "LopHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongSinhVien",
                table: "LopHoc");
        }
    }
}
