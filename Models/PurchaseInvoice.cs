using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Hóa đơn nhập
namespace BTL_nhom11_marketPC.Models
{
    [Table("HoaDonNhap")]
    public class PurchaseInvoice
    {
        [Key]
        [Column("MaHDN")]
        public string MaHDN { get; set; }

        [Required]
        [Column("MaNCC")]
        public string MaNCC { get; set; }

        [Required]
        [Column("MaNV")]
        public string MaNV { get; set; }

        [Required]
        [Column("NgayNhap")]
        public DateTime NgayNhap { get; set; }

        [Column("TongTien")]
        public decimal TongTien { get; set; }

        [ForeignKey("MaNCC")]
        public Supplier Supplier { get; set; }

        [ForeignKey("MaNV")]
        public Employee Employee { get; set; }

        public ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
    }
}
