using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//khuyến mãi
namespace BTL_nhom11_marketPC.Models
{
    [Table("KhuyenMai")]
    public class Promotion
    {
        [Key]
        [Column("MaKhuyenMai")]
        public string MaKhuyenMai { get; set; }

        [Required]
        [Column("TenKhuyenMai")]
        public string TenKhuyenMai { get; set; }

        [Column("PhanTramGiam")]
        public int PhanTramGiam { get; set; }

        [Required]
        [Column("NgayBatDau")]
        public DateTime NgayBatDau { get; set; }

        [Required]
        [Column("NgayKetThuc")]
        public DateTime NgayKetThuc { get; set; }

        public ICollection<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
    }
}
