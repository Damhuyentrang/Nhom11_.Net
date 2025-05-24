using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface IHardDriveView
    {
        List<HardDrive> HardDrives { set; }
        HardDrive SelectedHardDrive { get; set; }
        string MaOCung { get; set; }
        string TenOCung { get; set; }
        string LoaiOCung { get; set; }
        int DungLuong { get; set; }
        string MoTa { get; set; }

        void SetHardDriveList(List<HardDrive> hardDrives);

        event EventHandler AddHardDrive;
        event EventHandler UpdateHardDrive;
        event EventHandler DeleteHardDrive;
        event EventHandler SelectHardDrive;

        void ClearInputFields();
    }
}
