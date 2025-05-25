using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BTL_nhom11_marketPC.Models
{
    public class Promotion
    {
        public string MaKM { get; set; }
        public string TenKM { get; set; }
        public decimal GiaTriKM { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string MaKhuyenMai { get; internal set; }
        public string TenKhuyenMai { get; internal set; }
        public int PhanTramGiam { get; internal set; }
        public int PhanTramKM { get; internal set; }
    }
}