using Microsoft.EntityFrameworkCore;
namespace vesion15.Models
{
    

    public class QLDBContext : DbContext
    {
        public QLDBContext(DbContextOptions<QLDBContext> options) : base(options) { }
        public DbSet<Nganh> Nganhs { get; set; }
       
        public DbSet<HoSo> HoSos { get; set; }
        public DbSet<KetQua> KetQuas { get; set; }
        public DbSet<QuanTriVien> QuanTriViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nganh>().ToTable("Nganh");
           
            modelBuilder.Entity<HoSo>().ToTable("HoSo");
            modelBuilder.Entity<KetQua>().ToTable("KetQua");
            modelBuilder.Entity<QuanTriVien>().ToTable("QuanTriVien");
            modelBuilder.Entity<TaiKhoan>().ToTable("TaiKhoan");
            modelBuilder.Entity<Quyen>().ToTable("Quyen");
        }

        
    }

}
