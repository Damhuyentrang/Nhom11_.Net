using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreSupplier
    {
        private readonly IViewSupplier view;
        private readonly IRepository<Supplier> repository;

        public PreSupplier(IViewSupplier view, IRepository<Supplier> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadSuppliers()
        {
            var suppliers = repository.GetAll(); 
            view.UpdateSupplierList(suppliers); 
        }
    }
}
