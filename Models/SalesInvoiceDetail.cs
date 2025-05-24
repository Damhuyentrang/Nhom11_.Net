using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Chi tiết hóa đơn bán
namespace BTL_nhom11_marketPC.Models
{
    [Table("ChiTietHDB")]
    public class SalesInvoiceDetail
    {
        [Key]
        [Column("MaCTHDB")]
        public string MaCTHDB { get; set; }

        [Required]
        [Column("MaHDB")]
        public string MaHDB { get; set; }

        [Required]
        [Column("MaMay")]
        public string MaMay { get; set; }

        [Column("SoLuong")]
        public int SoLuong { get; set; }

        [Column("GiaBan")]
        public decimal GiaBan { get; set; }

        [Column("ThanhTien")]
        public decimal ThanhTien { get; set; }

        [Column("MaKhuyenMai")]
        public string MaKhuyenMai { get; set; }

        [ForeignKey("MaHDB")]
        public SalesInvoice SalesInvoice { get; set; }

        [ForeignKey("MaMay")]
        public Computer Computer { get; set; }

        [ForeignKey("MaKhuyenMai")]
        public Promotion Promotion { get; set; }
    }
}
