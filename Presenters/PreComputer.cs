using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace BTL_nhom11_marketPC.Presenters
{
    public class PreComputer
    {
        private readonly IComputerView _view;
        private readonly RelationshipMapper _mapper;

        public PreComputer(IComputerView view)
        {
            _view = view;
            _mapper = DatabaseContext.RelationshipMapper;

            _view.AddComputer += OnAddComputer;
            _view.UpdateComputer += OnUpdateComputer;
            _view.DeleteComputer += OnDeleteComputer;
            _view.SelectComputer += OnSelectComputer;

            LoadReferenceData();
        }

        public void LoadAllComputers()
        {
            var computers = _mapper.GetComputersWithRelationships();
            _view.Computers = computers;
        }

        public void LoadReferenceData()
        {
            _view.SetComputerTypes(_mapper.GetComputerTypesWithRelationships());
            _view.SetCPUs(_mapper.GetCPUsWithManufacturer());
            _view.SetRAMs(_mapper.GetRAMsWithManufacturer());
            _view.SetMainboards(_mapper.GetMainboardWithManufacturer());
            _view.SetGPUs(_mapper.GetGPUsWithManufacturer());
            _view.SetHardDrives(_mapper.GetHardDrived());
            _view.SetComputerScreens(_mapper.GetScreensWithManufacturer());
            _view.SetGraphicsCards(_mapper.GetGraphicsCard());
            _view.SetManufacturers(_mapper.GetManufacturersWithRelationships());
        }

        public void SetSelectedComputer(Computer computer)
        {
            _view.SelectedComputer = computer;
        }

        private void OnAddComputer(object sender, EventArgs e)
        {
            try
            {
                var computer = new Computer
                {
                    MaMay = _view.MaMay,
                    TenMay = _view.TenMay,
                    HinhAnh = _view.HinhAnh,
                    GhiChu = _view.GhiChu,
                    DonGia = _view.DonGia,
                    SoLuongTon = _view.SoLuongTon,
                    ThoiGianBaoHanh = _view.ThoiGianBaoHanh,
                    MaLoaiMay = _view.MaLoaiMay,
                    MaCPU = _view.MaCPU,
                    MaRAM = _view.MaRAM,
                    MaMainboard = _view.MaMainboard,
                    MaGPU = _view.MaGPU,
                    MaOCung = _view.MaOCung,
                    MaManHinh = _view.MaManHinh,
                    MaCard = _view.MaCard,
                    MaHSX = _view.MaHSX
                };

                if (_mapper.AddComputer(computer))
                {
                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllComputers();
                    _view.ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm mới thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm máy tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateComputer(object sender, EventArgs e)
        {
            try
            {
                var computer = new Computer
                {
                    MaMay = _view.MaMay,
                    TenMay = _view.TenMay,
                    HinhAnh = _view.HinhAnh,
                    GhiChu = _view.GhiChu,
                    DonGia = _view.DonGia,
                    SoLuongTon = _view.SoLuongTon,
                    ThoiGianBaoHanh = _view.ThoiGianBaoHanh,
                    MaLoaiMay = _view.MaLoaiMay,
                    MaCPU = _view.MaCPU,
                    MaRAM = _view.MaRAM,
                    MaMainboard = _view.MaMainboard,
                    MaGPU = _view.MaGPU,
                    MaOCung = _view.MaOCung,
                    MaManHinh = _view.MaManHinh,
                    MaCard = _view.MaCard,
                    MaHSX = _view.MaHSX
                };

                if (_mapper.UpdateComputer(computer))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllComputers();
                    _view.ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật máy tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteComputer(object sender, EventArgs e)
        {
            try
            {
                var selectedComputer = _view.SelectedComputer;
                if (selectedComputer != null && _mapper.DeleteComputer(selectedComputer.MaMay))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllComputers();
                    _view.ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa máy tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSelectComputer(object sender, EventArgs e)
        {
            var selectedComputer = _view.SelectedComputer;
            if (selectedComputer != null)
            {
                _view.SelectedComputer = selectedComputer;
            }
        }

    }
}
