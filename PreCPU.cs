using System;
using System.Linq;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreCPU
    {
        private readonly IViewCPU view;
        private readonly IRepository<CPU> repository;
        private readonly ManufacturerRepository hsxRepository;

        public PreCPU(IViewCPU view, IRepository<CPU> repository, ManufacturerRepository hsxRepository)
        {
            this.view = view;
            this.repository = repository;
            this.hsxRepository = hsxRepository ?? throw new ArgumentNullException(nameof(hsxRepository));
        }

        public void LoadCPUs()
        {
            var cpus = repository.GetAllWithForeignKey("HangSanXuat", "MaHSX", "TenHSX");
            if (cpus == null || !cpus.Any())
            {
                view.ShowError("Không tải được danh sách CPU.");
                return;
            }
            view.UpdateCPUList(cpus);
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
        public void AddCPU(CPU cpu)
        {
            repository.Add(cpu);
            LoadCPUs();
        }

        public void UpdateCPU(CPU cpu)
        {
            repository.Update(cpu);
            LoadCPUs();
        }

        public void DeleteCPU(string maCPU)
        {
            repository.Delete(maCPU);
            LoadCPUs();
        }
    }
}
