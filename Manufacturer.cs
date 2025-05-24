using System.ComponentModel.DataAnnotations;

namespace BTL_nhom11_marketPC.Models
{
    public class Manufacturer
    {
        [Key]
        public string MaHSX { get; set; }

        [Required]
        public string TenHSX { get; set; }
    }
}
