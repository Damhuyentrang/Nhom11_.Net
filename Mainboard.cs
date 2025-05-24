using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_nhom11_marketPC.Models
{
    public class Mainboard
    {
        [Key]
        public string MaMainboard { get; set; }

        [Required]
        public string TenMainboard { get; set; }

        public string Socket { get; set; }

        public string Mota { get; set; }

        [ForeignKey("Manufacturer")]
        public string MaHSX { get; set; } // Khóa ngoại trực tiếp từ CSDL
        public virtual Manufacturer Manufacturer { get; set; }
    }
}