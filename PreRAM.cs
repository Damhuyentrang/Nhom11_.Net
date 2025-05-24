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
    public class PreRAM
    {
        private readonly IViewRAM view;
        private readonly IRepository<RAM> repository;
        private readonly ManufacturerRepository hsxRepository;

        public PreRAM(IViewRAM view, IRepository<RAM> repository, ManufacturerRepository hsxRepository)
        {
            this.view = view;
            this.repository = repository;
            this.hsxRepository = hsxRepository ?? throw new ArgumentNullException(nameof(hsxRepository));
        }

        public void LoadRAMs()
        {
            var rams = repository.GetAllWithForeignKey("HangSanXuat", "MaHSX", "TenHSX");
            if (rams == null || !rams.Any())
            {
                view.ShowError("Không tải được danh sách RAM.");
                return;
            }
            view.UpdateRAMList(rams);
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
        public void AddRAM(RAM ram)
        {
            repository.Add(ram);
            LoadRAMs();
        }

        public void UpdateRAM(RAM ram)
        {
            repository.Update(ram);
            LoadRAMs();
        }

        public void DeleteRAM(string maRAM)
        {
            repository.Delete(maRAM);
            LoadRAMs();
        }
    }
}
