using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_nhom11_marketPC.Models
{
    [Table("GPU")]
    public class GPU
    {
        [Key]
        [Column("MaGPU")]
        public string MaGPU { get; set; }

        [Column("LoaiGPU")]
        public string LoaiGPU { get; set; }

        [Column("DungLuong")]
        public int DungLuong { get; set; }

        [Column("MoTa")]
        public string MoTa { get; set; }

        [Column("MaHSX")]
        public string MaHSX { get; set; }

        [ForeignKey("MaHSX")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}