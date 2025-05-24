using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    public class Mainboard
    {
        [Key]
        [Column("MaMainboard")]
        public string MaMainboard { get; set; }
        [Column("TenMainboard")]
        public string TenMainboard { get; set; }
        [Column("Socket")]
        public string Socket { get; set; }
        
        [Column("MoTa")]
        public string MoTa { get; set; }

        [Column("MaHSX")]
        public string MaHSX { get; set; }

        [ForeignKey("MaHSX")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
