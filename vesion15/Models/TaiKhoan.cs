﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vesion15.Models
{
    public class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
        public string? Role { get; set; }
    }
}
