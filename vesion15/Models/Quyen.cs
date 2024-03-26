using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vesion15.Models
{
    public class Quyen
    {
        [Key]
        public int MaQuyen { get; set; }
        public string? TenQuyen { get; set; }
        public int MaTK { get; set; }
    
       
    }
}
