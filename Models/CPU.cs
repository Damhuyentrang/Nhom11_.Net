using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTL_nhom11_marketPC.Models
{
    [Table("CPU")]
    public class CPU
    {
        [Key]
        [Column("MaCPU")]
        public string MaCPU {  get; set; }
        [Column("TenCPU")]
        public string TenCPU { get; set; }
        [Column("TocDo")]
        public string TocDo { get; set;}
        [Column("Socket")]
        public string Socket { get; set;}
        [Column("MoTa")]
        public string MoTa { get; set;}
        [Column("MaHSX")]
        public string MaHSX { get; set; }

        [ForeignKey("MaHSX")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
