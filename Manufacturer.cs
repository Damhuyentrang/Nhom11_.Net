using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BTL_nhom11_marketPC.Models
{
    public class Manufacturer
    {
        [Key]
        public string MaHSX { get; set; }

        [Required]
        public string TenHSX { get; set; }

    }
}

