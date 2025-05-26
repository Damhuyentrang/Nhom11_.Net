using System.Linq;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreManufacturer
    {
        private readonly IViewManufacturer view;
        private readonly ManufacturerRepository repository;

        public PreManufacturer(IViewManufacturer view, ManufacturerRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }
        public void LoadManufacturers()
        {
            var manufacturers = repository.GetAll();
            if (manufacturers == null || !manufacturers.Any())
            {
                view.ShowError("Không tải được danh sách hãng sản xuất.");
                return;
            }
            view.UpdateManufacturerList(manufacturers);
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            repository.Add(manufacturer);
            LoadManufacturers();
        }
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            repository.Update(manufacturer);
            LoadManufacturers();
        }

        public void DeleteManufacturer(string maHSX)
        {
            repository.Delete(maHSX);
            LoadManufacturers();
        }
    }
}
