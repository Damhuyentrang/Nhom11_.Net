using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("RAM")]
    public class RAM
    {
        [Key]
        [Column("MaRAM")]
        public string MaRAM { get; set; }
        [Column("TenRAM")]
        public string TenRAM { get; set; }
        [Column("Bus")]
        public int Bus { get; set; }
        [Column("DungLuong")]
        public int DungLuong { get; set; }
        [Column("MoTa")]
        public string MoTa { get; set; }

        [Column("MaHSX")]
        public string MaHSX { get; set; }

        [Required]
        [ForeignKey("MaHSX")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
