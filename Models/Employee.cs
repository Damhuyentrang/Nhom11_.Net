using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("NhanVien")]
    public class Employee
    {
        [Key]
        [Column("MaNV")]
        public string MaNV { get; set; }

        [Required]
        [Column("TenNV")]
        public string TenNV { get; set; }

        [Column("NgaySinh")]
        public DateTime NgaySinh { get; set; }

        [Column("GioiTinh")]
        public string GioiTinh { get; set; }

        [Column("DiaChi")]
        public string DiaChi { get; set; }

        [Required]
        [Column("SoDienThoai")]
        public string SoDienThoai { get; set; }

        [Column("VaiTro")]
        public string VaiTro { get; set; }

        [Required]
        [Column("Username")]
        public string Username { get; set; }

        [Required]
        [Column("MatKhau")]
        public string MatKhau { get; set; }

        public ICollection<SalesInvoice> SalesInvoices { get; set; }
        public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
    }
}
