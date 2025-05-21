using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    public class GPU
    {
        [Key]
        public string MaGPU { get; set; }

        [Required]
        public string LoaiGPU { get; set; }

        public int Dungluong { get; set; }

        public string Mota { get; set; }

        [ForeignKey("Manufacturer")]
        public string MaHSX { get; set; } // Khóa ngoại trực tiếp từ CSDL
    }
}
