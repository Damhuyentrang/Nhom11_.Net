using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("HangSanXuat")]
    public class Manufacturer
    {
        [Key]
        [Column("MaHSX")]
        public string MaHSX { get; set; }
        [Column("TenHSX")]
        public string TenHSX { get; set; }

        public ICollection<GPU> GPUs { get; set; }
        public ICollection<CPU> CPUs { get; set; }
        public ICollection<RAM> RAMs { get; set; }
        public ICollection<Mainboard> Mainboards { get; set; }
        public ICollection<ComputerScreen> ComputerScreens { get; set; }
        public ICollection<Computer> Computers { get; set; }
    }
}
