using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vesion15.Models
{
    public class HoSo
    {
        [Key]
        public int MaHS { get; set; }
        public string? HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? AnhHoSo { get; set; }
        public string? MaCanCuocCongDan { get; set; }
        public int MaNganh { get; set; }
        [ForeignKey("MaNganh")]
        public Nganh? Nganh { get; set; }
        public string? TrangThai { get; set; } = "Chờ duyệt";
        public ICollection<KetQua>? KetQuas { get; set; }
    }
}
