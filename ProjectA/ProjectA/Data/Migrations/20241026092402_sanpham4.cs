using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectA.Data.Migrations
{
    /// <inheritdoc />
    public partial class sanpham4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_BoSuuTap_BoSuuTapId1",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "BoSuuTapId1",
                table: "SanPham",
                newName: "BoSuuTapId");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_BoSuuTapId1",
                table: "SanPham",
                newName: "IX_SanPham_BoSuuTapId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_BoSuuTap_BoSuuTapId",
                table: "SanPham",
                column: "BoSuuTapId",
                principalTable: "BoSuuTap",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_BoSuuTap_BoSuuTapId",
                table: "SanPham");

            migrationBuilder.RenameColumn(
                name: "BoSuuTapId",
                table: "SanPham",
                newName: "BoSuuTapId1");

            migrationBuilder.RenameIndex(
                name: "IX_SanPham_BoSuuTapId",
                table: "SanPham",
                newName: "IX_SanPham_BoSuuTapId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_BoSuuTap_BoSuuTapId1",
                table: "SanPham",
                column: "BoSuuTapId1",
                principalTable: "BoSuuTap",
                principalColumn: "Id");
        }
    }
}
