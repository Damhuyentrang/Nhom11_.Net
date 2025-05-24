using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    [Table("MayTinh")]
    public class Computer
    {
        [Key]
        [Column("MaMay")]
        public string MaMay { get; set; }
        [Column("TenMay")]
        public string TenMay { get; set; }
        [Column("HinhAnh")]
        public string HinhAnh { get; set; }
        [Column("GhiChu")]
        public string GhiChu { get; set; }
        [Column("DonGia")]
        public decimal DonGia { get; set; }
        [Column("SoLuongTon")]
        public int SoLuongTon { get; set; }
        [Column("ThoiGianBaoHanh")]
        public int ThoiGianBaoHanh { get; set; }
        [Column("MaLoaiMay")]
        public string MaLoaiMay { get; set; }
        [ForeignKey("MaLoaiMay")]
        public ComputerType ComputerType { get; set; }
        [Column("MaCPU")]
        public string MaCPU { get; set; }
        [ForeignKey("MaCPU")]
        public CPU CPU { get; set; }

        [Column("MaRAM")]
        public string MaRAM { get; set; }
        [ForeignKey("MaRAM")]
        public RAM RAM { get; set; }

        [Column("MaMainboard")]
        public string MaMainboard { get; set; }
        [ForeignKey("MaMainboard")]
        public Mainboard Mainboard { get; set; }

        [Column("MaGPU")]
        public string MaGPU { get; set; }
        [ForeignKey("MaGPU")]
        public GPU GPU { get; set; }

        [Column("MaOCung")]
        public string MaOCung { get; set; }
        [ForeignKey("MaOCung")]
        public HardDrive HardDrive { get; set; }

        [Column("MaManHinh")]
        public string MaManHinh { get; set; }
        [ForeignKey("MaManHinh")]
        public ComputerScreen ComputerScreen { get; set; }

        [Column("MaCard")]
        public string MaCard { get; set; }
        [ForeignKey("MaCard")]
        public GraphicsCard GraphicsCard { get; set; }

        [Column("MaHSX")]
        public string MaHSX { get; set; }

        [ForeignKey("MaHSX")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
        public ICollection<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
    }
}
