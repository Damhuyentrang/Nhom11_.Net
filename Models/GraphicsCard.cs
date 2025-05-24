using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("CardDoHoa")]
    public class GraphicsCard
    {
        [Key]
        [Column("MaCard")]
        public string MaCard {  get; set; }

        [Column("TenCard")]
        public string TenCard { get; set; }

        public ICollection<Computer> Computers { get; set; }
    }
}
