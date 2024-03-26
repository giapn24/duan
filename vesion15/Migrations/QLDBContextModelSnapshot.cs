﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vesion15.Models;

#nullable disable

namespace vesion15.Migrations
{
    [DbContext(typeof(QLDBContext))]
    partial class QLDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("vesion15.Models.HoSo", b =>
                {
                    b.Property<int>("MaHS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHS"));

                    b.Property<int>("MaHV")
                        .HasColumnType("int");

                    b.Property<int>("MaNganh")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNop")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHS");

                    b.HasIndex("MaHV");

                    b.HasIndex("MaNganh");

                    b.ToTable("HoSo", (string)null);
                });

            modelBuilder.Entity("vesion15.Models.HocVien", b =>
                {
                    b.Property<int>("MaHV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHV"));

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.HasKey("MaHV");

                    b.ToTable("HocVien", (string)null);
                });

            modelBuilder.Entity("vesion15.Models.KetQua", b =>
                {
                    b.Property<int>("MaKQ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKQ"));

                    b.Property<float>("Diem")
                        .HasColumnType("real");

                    b.Property<string>("HienThi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaHS")
                        .HasColumnType("int");

                    b.HasKey("MaKQ");

                    b.HasIndex("MaHS");

                    b.ToTable("KetQua", (string)null);
                });

            modelBuilder.Entity("vesion15.Models.Nganh", b =>
                {
                    b.Property<int>("MaNganh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNganh"));

                    b.Property<string>("TenNganh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNganh");

                    b.ToTable("Nganh", (string)null);
                });

            modelBuilder.Entity("vesion15.Models.QuanTriVien", b =>
                {
                    b.Property<int>("MaQTV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaQTV"));

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaQTV");

                    b.ToTable("QuanTriVien", (string)null);
                });

            modelBuilder.Entity("vesion15.Models.Quyen", b =>
                {
                    b.Property<int>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaQuyen"));

                    b.Property<int>("MaTK")
                        .HasColumnType("int");

                    b.Property<string>("TenQuyen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaQuyen");

                    b.ToTable("Quyen", (string)null);
                });

            modelBuilder.Entity("vesion15.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTK"));

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTK");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("vesion15.Models.HoSo", b =>
                {
                    b.HasOne("vesion15.Models.HocVien", "HocVien")
                        .WithMany("HoSos")
                        .HasForeignKey("MaHV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vesion15.Models.Nganh", "Nganh")
                        .WithMany("HoSos")
                        .HasForeignKey("MaNganh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HocVien");

                    b.Navigation("Nganh");
                });

            modelBuilder.Entity("vesion15.Models.KetQua", b =>
                {
                    b.HasOne("vesion15.Models.HoSo", "HoSo")
                        .WithMany("KetQuas")
                        .HasForeignKey("MaHS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoSo");
                });

            modelBuilder.Entity("vesion15.Models.HoSo", b =>
                {
                    b.Navigation("KetQuas");
                });

            modelBuilder.Entity("vesion15.Models.HocVien", b =>
                {
                    b.Navigation("HoSos");
                });

            modelBuilder.Entity("vesion15.Models.Nganh", b =>
                {
                    b.Navigation("HoSos");
                });
#pragma warning restore 612, 618
        }
    }
}
