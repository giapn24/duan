using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vesion15.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocVien",
                columns: table => new
                {
                    MaHV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien", x => x.MaHV);
                });

            migrationBuilder.CreateTable(
                name: "Nganh",
                columns: table => new
                {
                    MaNganh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNganh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nganh", x => x.MaNganh);
                });

            migrationBuilder.CreateTable(
                name: "QuanTriVien",
                columns: table => new
                {
                    MaQTV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanTriVien", x => x.MaQTV);
                });

            migrationBuilder.CreateTable(
                name: "HoSo",
                columns: table => new
                {
                    MaHS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHV = table.Column<int>(type: "int", nullable: false),
                    HocVienMaHV = table.Column<int>(type: "int", nullable: true),
                    MaNganh = table.Column<int>(type: "int", nullable: true),
                    NganhMaNganh = table.Column<int>(type: "int", nullable: true),
                    NgayNop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSo", x => x.MaHS);
                    table.ForeignKey(
                        name: "FK_HoSo_HocVien_HocVienMaHV",
                        column: x => x.HocVienMaHV,
                        principalTable: "HocVien",
                        principalColumn: "MaHV");
                    table.ForeignKey(
                        name: "FK_HoSo_Nganh_NganhMaNganh",
                        column: x => x.NganhMaNganh,
                        principalTable: "Nganh",
                        principalColumn: "MaNganh");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaQTV = table.Column<int>(type: "int", nullable: false),
                    QuanTriVienMaQTV = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_QuanTriVien_QuanTriVienMaQTV",
                        column: x => x.QuanTriVienMaQTV,
                        principalTable: "QuanTriVien",
                        principalColumn: "MaQTV");
                });

            migrationBuilder.CreateTable(
                name: "KetQua",
                columns: table => new
                {
                    MaKQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHS = table.Column<int>(type: "int", nullable: false),
                    HoSoMaHS = table.Column<int>(type: "int", nullable: true),
                    Diem = table.Column<float>(type: "real", nullable: false),
                    HienThi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQua", x => x.MaKQ);
                    table.ForeignKey(
                        name: "FK_KetQua_HoSo_HoSoMaHS",
                        column: x => x.HoSoMaHS,
                        principalTable: "HoSo",
                        principalColumn: "MaHS");
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTK = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanMaTK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.MaQuyen);
                    table.ForeignKey(
                        name: "FK_Quyen_TaiKhoan_TaiKhoanMaTK",
                        column: x => x.TaiKhoanMaTK,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_HocVienMaHV",
                table: "HoSo",
                column: "HocVienMaHV");

            migrationBuilder.CreateIndex(
                name: "IX_HoSo_NganhMaNganh",
                table: "HoSo",
                column: "NganhMaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_HoSoMaHS",
                table: "KetQua",
                column: "HoSoMaHS");

            migrationBuilder.CreateIndex(
                name: "IX_Quyen_TaiKhoanMaTK",
                table: "Quyen",
                column: "TaiKhoanMaTK");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuanTriVienMaQTV",
                table: "TaiKhoan",
                column: "QuanTriVienMaQTV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KetQua");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "HoSo");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "HocVien");

            migrationBuilder.DropTable(
                name: "Nganh");

            migrationBuilder.DropTable(
                name: "QuanTriVien");
        }
    }
}
