using System;
using System.Linq;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreGPU
    {
        private readonly IViewGPU view;
        private readonly IRepository<GPU> repository;
        private readonly ManufacturerRepository hsxRepository;

        public PreGPU(IViewGPU view, IRepository<GPU> repository, ManufacturerRepository hsxRepository)
        {
            this.view = view;
            this.repository = repository;
            this.hsxRepository = hsxRepository ?? throw new ArgumentNullException(nameof(hsxRepository));
        }

        public void LoadGPUs()
        {
            var gpus = repository.GetAllWithForeignKey("HangSanXuat", "MaHSX", "TenHSX");
            if (gpus == null || !gpus.Any())
            {
                view.ShowError("Không tải được danh sách GPU.");
                return;
            }
            view.UpdateGPUList(gpus);
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
        public void AddGPU(GPU gpu)
        {
            repository.Add(gpu);
            LoadGPUs();
        }

        public void UpdateGPU(GPU gpu)
        {
            repository.Update(gpu);
            LoadGPUs();
        }

        public void DeleteGPU(string maGPU)
        {
            repository.Delete(maGPU);
            LoadGPUs();
        }
    }
}
