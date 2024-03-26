using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace vesion15.Models
{
    public class Nganh
    {
        [Key]
        public int MaNganh { get; set; }
        public string? TenNganh { get; set; }
        public string? AnhNganh { get; set; }
        public string? ThongTin {  get; set; }
        public ICollection<HoSo>? HoSos { get; set; }
    }
}
