using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vesion15.Models
{
    public class KetQua
    {
        [Key]
        public int MaKQ { get; set; }
        public int MaHS { get; set; }
        [ForeignKey("MaHS")]
        public HoSo? HoSo { get; set; }
        public float Diem { get; set; }
        public string? HienThi { get; set; }
    }
}
