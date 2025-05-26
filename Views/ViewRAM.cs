using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewRAM
    {
        void UpdateRAMList(List<RAM> rams);
        void UpdateHSXList(List<Manufacturer> manufacturers);
        void ShowError(string message);
    }
}
