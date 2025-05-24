using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Forms;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreSupplier
    {
        private readonly IViewSupplier view;
        private readonly IRepository<Supplier> repository;
        private FrmSupplier frmSupplier;
        private SupplierRepository repository1;

        public PreSupplier(IViewSupplier view, IRepository<Supplier> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public PreSupplier(FrmSupplier frmSupplier, SupplierRepository repository1)
        {
            this.frmSupplier = frmSupplier;
            this.repository1 = repository1;
        }

        public void LoadSuppliers()
        {
            var suppliers = repository.GetAll();
            view.UpdateSupplierList(suppliers);
        }
    }
}
