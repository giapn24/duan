using System.ComponentModel.DataAnnotations;

namespace vesion15.Models
{
    public class QuanTriVien
    {
        [Key]
        public int MaQTV { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
       
    }
}
