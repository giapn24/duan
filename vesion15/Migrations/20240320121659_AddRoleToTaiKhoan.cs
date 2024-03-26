using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vesion15.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToTaiKhoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_HocVien_HocVienMaHV",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_Nganh_NganhMaNganh",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQua_HoSo_HoSoMaHS",
                table: "KetQua");

            migrationBuilder.DropForeignKey(
                name: "FK_Quyen_TaiKhoan_TaiKhoanMaTK",
                table: "Quyen");

            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoan_QuanTriVien_QuanTriVienMaQTV",
                table: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoan_QuanTriVienMaQTV",
                table: "TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_Quyen_TaiKhoanMaTK",
                table: "Quyen");

            migrationBuilder.DropIndex(
                name: "IX_KetQua_HoSoMaHS",
                table: "KetQua");

            migrationBuilder.DropIndex(
                name: "IX_HoSo_HocVienMaHV",
                table: "HoSo");

            migrationBuilder.DropIndex(
                name: "IX_HoSo_NganhMaNganh",
                table: "HoSo");

            migrationBuilder.DropColumn(
                name: "MaQTV",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "QuanTriVienMaQTV",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "TaiKhoanMaTK",
                table: "Quyen");

            migrationBuilder.DropColumn(
                name: "HoSoMaHS",
                table: "KetQua");

            migrationBuilder.DropColumn(
                name: "HocVienMaHV",
                table: "HoSo");

            migrationBuilder.DropColumn(
                name: "NganhMaNganh",
                table: "HoSo");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MaNganh",
                table: "HoSo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_MaHS",
                table: "KetQua",
                column: "MaHS");

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_MaHV",
                table: "HoSo",
                column: "MaHV");

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_MaNganh",
                table: "HoSo",
                column: "MaNganh");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_HocVien_MaHV",
                table: "HoSo",
                column: "MaHV",
                principalTable: "HocVien",
                principalColumn: "MaHV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_Nganh_MaNganh",
                table: "HoSo",
                column: "MaNganh",
                principalTable: "Nganh",
                principalColumn: "MaNganh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQua_HoSo_MaHS",
                table: "KetQua",
                column: "MaHS",
                principalTable: "HoSo",
                principalColumn: "MaHS",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_HocVien_MaHV",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoSo_Nganh_MaNganh",
                table: "HoSo");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQua_HoSo_MaHS",
                table: "KetQua");

            migrationBuilder.DropIndex(
                name: "IX_KetQua_MaHS",
                table: "KetQua");

            migrationBuilder.DropIndex(
                name: "IX_HoSo_MaHV",
                table: "HoSo");

            migrationBuilder.DropIndex(
                name: "IX_HoSo_MaNganh",
                table: "HoSo");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "TaiKhoan");

            migrationBuilder.AddColumn<int>(
                name: "MaQTV",
                table: "TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuanTriVienMaQTV",
                table: "TaiKhoan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaiKhoanMaTK",
                table: "Quyen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoSoMaHS",
                table: "KetQua",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaNganh",
                table: "HoSo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HocVienMaHV",
                table: "HoSo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NganhMaNganh",
                table: "HoSo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuanTriVienMaQTV",
                table: "TaiKhoan",
                column: "QuanTriVienMaQTV");

            migrationBuilder.CreateIndex(
                name: "IX_Quyen_TaiKhoanMaTK",
                table: "Quyen",
                column: "TaiKhoanMaTK");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_HoSoMaHS",
                table: "KetQua",
                column: "HoSoMaHS");

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_HocVienMaHV",
                table: "HoSo",
                column: "HocVienMaHV");

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_NganhMaNganh",
                table: "HoSo",
                column: "NganhMaNganh");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_HocVien_HocVienMaHV",
                table: "HoSo",
                column: "HocVienMaHV",
                principalTable: "HocVien",
                principalColumn: "MaHV");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSo_Nganh_NganhMaNganh",
                table: "HoSo",
                column: "NganhMaNganh",
                principalTable: "Nganh",
                principalColumn: "MaNganh");

            migrationBuilder.AddForeignKey(
                name: "FK_KetQua_HoSo_HoSoMaHS",
                table: "KetQua",
                column: "HoSoMaHS",
                principalTable: "HoSo",
                principalColumn: "MaHS");

            migrationBuilder.AddForeignKey(
                name: "FK_Quyen_TaiKhoan_TaiKhoanMaTK",
                table: "Quyen",
                column: "TaiKhoanMaTK",
                principalTable: "TaiKhoan",
                principalColumn: "MaTK");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoan_QuanTriVien_QuanTriVienMaQTV",
                table: "TaiKhoan",
                column: "QuanTriVienMaQTV",
                principalTable: "QuanTriVien",
                principalColumn: "MaQTV");
        }
    }
}
