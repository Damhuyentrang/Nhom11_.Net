using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewGPU
    {
        void UpdateGPUList(List<GPU> gpus);
        void UpdateHSXList(List<Manufacturer> manufacturers); 
        void ShowError(string message);
    }
}
