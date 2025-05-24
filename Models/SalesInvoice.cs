using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Hóa đơn bán
namespace BTL_nhom11_marketPC.Models
{
    [Table("HoaDonBan")]
    public class SalesInvoice
    {
        [Key]
        [Column("MaHDB")]
        public string MaHDB { get; set; }

        [Required]
        [Column("MaKhach")]
        public string MaKhach { get; set; }

        [Required]
        [Column("MaNV")]
        public string MaNV { get; set; }

        [Required]
        [Column("NgayBan")]
        public DateTime NgayBan { get; set; }

        [Column("TongTien")]
        public decimal TongTien { get; set; }

        [Required]
        [Column("TrangThaiDonHang")]
        public string TrangThaiDonHang { get; set; }

        [ForeignKey("MaKhach")]
        public Customer Customer { get; set; }

        [ForeignKey("MaNV")]
        public Employee Employee { get; set; }

        public ICollection<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
    }
}
