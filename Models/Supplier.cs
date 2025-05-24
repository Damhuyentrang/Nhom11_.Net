using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("NhaCungCap")]
    public class Supplier
    {
        [Key]
        [Column("MaNCC")]
        public string MaNCC { get; set; }

        [Required]
        [Column("TenNCC")]
        public string TenNCC { get; set; }

        [Required]
        [Column("DiaChi")]
        public string DiaChi { get; set; }

        [Required]
        [Column("SoDienThoai")]
        public string SoDienThoai { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        public ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
    }
}
