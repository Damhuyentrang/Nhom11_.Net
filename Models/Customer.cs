using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("KhachHang")]
    public class Customer
    {
        [Key]
        [Column("MaKhach")]
        public string MaKhach { get; set; }

        [Required]
        [Column("TenKhach")]
        public string TenKhach { get; set; }

        [Column("GioiTinh")]
        public string GioiTinh { get; set; }

        [Column("NgaySinh")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [Column("SoDienThoai")]
        public string SoDienThoai { get; set; }

        [Column("DiaChi")]
        public string DiaChi { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        public ICollection<SalesInvoice> SalesInvoices { get; set; }
    }
}
