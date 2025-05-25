using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Views;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Database.Repositories;
using System;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreSupplier
    {
        private readonly IViewSupplier view;
        private readonly SupplierRepository repository;

        public object MaNCC { get; internal set; }

        public PreSupplier(IViewSupplier view, SupplierRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadSuppliers()
        {
            try
            {
                var list = repository.GetAll();
                view.UpdateSupplierList(list);
            }
            catch (Exception ex)
            {
                view.ShowError("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        public void AddSupplier(Supplier supplier)
        {
            repository.Add(supplier);
            LoadSuppliers();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            repository.Update(supplier);
            LoadSuppliers();
        }

        public void DeleteSupplier(string maNCC)
        {
            repository.Delete(maNCC);
            LoadSuppliers();
        }

        internal void DeleteSupplier(object maNCC)
        {
            throw new NotImplementedException();
        }

        internal void LoadSupplier()
        {
            throw new NotImplementedException();
        }
    }
}
