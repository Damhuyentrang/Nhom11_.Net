using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Chi tiết hóa đơn nhập
namespace BTL_nhom11_marketPC.Models
{
    [Table("ChiTietHDN")]
    public class PurchaseInvoiceDetail
    {
        [Key]
        [Column("MaCTHDN")]
        public string MaCTHDN { get; set; }

        [Required]
        [Column("MaHDN")]
        public string MaHDN { get; set; }

        [Required]
        [Column("MaMay")]
        public string MaMay { get; set; }

        [Column("SoLuong")]
        public int SoLuong { get; set; }

        [Column("DonGia")]
        public decimal DonGia { get; set; }

        [Column("ThanhTien")]
        public decimal ThanhTien { get; set; }

        [ForeignKey("MaHDN")]
        public PurchaseInvoice PurchaseInvoice { get; set; }

        [ForeignKey("MaMay")]
        public Computer Computer { get; set; }
    }
}
