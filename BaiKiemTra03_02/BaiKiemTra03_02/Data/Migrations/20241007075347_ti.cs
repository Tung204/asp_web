using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiKiemTra03.Data.Migrations
{
    /// <inheritdoc />
    public partial class ti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdSach",
                table: "Sach",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "TieuDe",
                table: "Sach",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TieuDe",
                table: "Sach");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sach",
                newName: "IdSach");
        }
    }
}
