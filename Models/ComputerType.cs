using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTL_nhom11_marketPC.Models
{
    [Table("LoaiMay")]
    public class ComputerType
    {
        [Key]
        [Column("MaLoaiMay")]
        public string MaLoaiMay { get; set; }

        [Column("TenLoaiMay")]
        public string TenLoaiMay { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
