using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface IComputerTypeView
    {
        List<ComputerType> ComputerTypes { set; }
        ComputerType SelectedComputertype { get; set; }
        string MaLoaiMay { get; set; }
        string TenLoaiMay { get; set; }

        void SetComputerTypeList(List<ComputerType> computerTypes);

        // Events for Presenter to handle
        event EventHandler AddComputerType;
        event EventHandler UpdateComputerType;
        event EventHandler DeleteComputerType;
        event EventHandler SelectComputerType;


        // Methods to control
        void ClearInputFields();
    }
}
