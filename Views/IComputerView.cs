using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface IComputerView
    {
        List<Computer> Computers { set; }
        Computer SelectedComputer { get; set; }

        string MaMay { get; set; }
        string TenMay { get; set; }
        string HinhAnh { get; set; }
        string GhiChu { get; set; }
        decimal DonGia { get; set; }
        int SoLuongTon { get; set; }
        int ThoiGianBaoHanh { get; set; }
        string MaLoaiMay { get; set; }
        string MaCPU { get; set; }
        string MaRAM { get; set; }
        string MaMainboard { get; set; }
        string MaGPU { get; set; }
        string MaOCung { get; set; }
        string MaManHinh { get; set; }
        string MaCard { get; set; }
        string MaHSX { get; set; }

        // Methods to bind dropdowns
        void SetComputerTypes(List<ComputerType> computerTypes);
        void SetCPUs(List<CPU> cpus);
        void SetRAMs(List<RAM> rams);
        void SetMainboards(List<Mainboard> mainboards);
        void SetGPUs(List<GPU> gpus);
        void SetHardDrives(List<HardDrive> hardDrives);
        void SetComputerScreens(List<ComputerScreen> screens);
        void SetGraphicsCards(List<GraphicsCard> graphicsCards);
        void SetManufacturers(List<Manufacturer> manufacturers);

        // Events for Presenter to handle
        event EventHandler AddComputer;
        event EventHandler UpdateComputer;
        event EventHandler DeleteComputer;
        event EventHandler SelectComputer;


        // Methods to control
        void ClearInputFields();

    }
}
