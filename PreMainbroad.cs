using System;
using System.Linq;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using BTL_nhom11_marketPC.Database.Repositories;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreMainbroad
    {
        private readonly IViewMainboard view;
        private readonly IRepository<Mainboard> repository;
        private readonly ManufacturerRepository hsxRepository;

        public PreMainbroad(IViewMainboard view, IRepository<Mainboard> repository, ManufacturerRepository hsxRepository)
        {
            this.view = view;
            this.repository = repository;
            this.hsxRepository = hsxRepository ?? throw new ArgumentNullException(nameof(hsxRepository));
        }

        public void LoadMainboards()
        {
            var mainboards = repository.GetAllWithForeignKey("HangSanXuat", "MaHSX", "TenHSX");
            if (mainboards == null || !mainboards.Any())
            {
                view.ShowError("Không tải được danh sách mainboard.");
                return;
            }
            view.UpdateMainboardList(mainboards);
        }

        public void LoadManufacturers()
        {
            var manufacturers = hsxRepository.GetAll();
            if (manufacturers == null || !manufacturers.Any())
            {
                view.ShowError("Không tải được danh sách hãng sản xuất.");
                return;
            }
            view.UpdateHSXList(manufacturers);
        }

        public void AddMainboard(Mainboard mainboard)
        {
            repository.Add(mainboard);
            LoadMainboards();
        }

        public void UpdateMainboard(Mainboard mainboard)
        {
            repository.Update(mainboard);
            LoadMainboards();
        }

        public void DeleteMainboard(string maMainboard)
        {
            repository.Delete(maMainboard);
            LoadMainboards();
        }
    }
}