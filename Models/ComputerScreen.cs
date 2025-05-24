using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("ManHinh")]
    public class ComputerScreen
    {
        [Key]
        [Column("MaManHinh")]
        public string MaManHinh { get; set; }
        [Column("TenManHinh")]
        public string TenManHinh { get; set; }
        [Column("DoPhanGiai")]
        public string DoPhanGiai { get; set; }
        [Column("KichThuoc")]
        public string KichThuoc {  get; set; }
        [Column("MaHSX")]
        public string MaHSX { get; set; }

        [ForeignKey("MaHSX")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Computer> Computers { get; set; }

    }
}
