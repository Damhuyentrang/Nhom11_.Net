using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BTL_nhom11_marketPC.Views
{
    public interface IViewSupplier
    {
        void UpdateSupplierList(List<Supplier> suppliers);
    }
}
