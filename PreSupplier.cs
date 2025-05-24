using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

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
