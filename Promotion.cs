using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//models khuyến mãi
namespace BTL_nhom11_marketPC.Models
{
    public class Promotion
    {
        public string MaKhuyenMai { get; set; }
        public string TenKhuyenMai { get; set; }
        public int PhanTramGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
