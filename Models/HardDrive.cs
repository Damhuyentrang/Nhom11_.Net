using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("OCung")]
    public class HardDrive
    {
        [Key]
        [Column("MaOCung")]
        public string MaOCung { get; set; }
        [Column("TenOCung")]
        public string TenOCung { get; set; }
        [Column("LoaiOCung")]
        public string LoaiOCung { get; set; }
        [Column("DungLuong")]
        public int DungLuong { get; set; }
        [Column("MoTa")]
        public string MoTa { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
