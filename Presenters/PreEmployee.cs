using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreEmployee
    {
        private readonly IEmployeeView _view;
        private readonly RelationshipMapper _mapper;

        public PreEmployee(IEmployeeView view)
        {
            _view = view;
            _mapper = new RelationshipMapper();

            // Gắn các sự kiện từ giao diện
            _view.AddEmployee += OnAddEmployee;
            _view.UpdateEmployee += OnUpdateEmployee;
            _view.DeleteEmployee += OnDeleteEmployee;
            _view.SelectEmployee += OnSelectEmployee;
        }

        public void LoadAllEmployees()
        {
            _view.Employees = _mapper.GetEmployees();
        }

        private void OnAddEmployee(object sender, EventArgs e)
        {
            var employee = new Employee
            {
                MaNV = _view.MaNV,
                TenNV = _view.TenNV,
                NgaySinh = _view.NgaySinh,
                GioiTinh = _view.GioiTinh,
                DiaChi = _view.DiaChi,
                SoDienThoai = _view.SoDienThoai,
                VaiTro = _view.VaiTro
            };

            if (_mapper.AddEmployee(employee)) 
            {
                LoadAllEmployees();
                _view.ClearInputFields();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateEmployee(object sender, EventArgs e)
        {
            var employee = new Employee
            {
                MaNV = _view.MaNV,
                TenNV = _view.TenNV,
                NgaySinh = _view.NgaySinh,
                GioiTinh = _view.GioiTinh,
                DiaChi = _view.DiaChi,
                SoDienThoai = _view.SoDienThoai,
                VaiTro= _view.VaiTro
            };

            if (_mapper.UpdateEmployee(employee)) 
            {
                LoadAllEmployees();
                _view.ClearInputFields();
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteEmployee(object sender, EventArgs e)
        {
            var selectedEmployee = _view.SelectedEmployee;
            if (selectedEmployee != null)
            {
                if (_mapper.DeleteEmployee(selectedEmployee.MaNV)) 
                {
                    LoadAllEmployees();
                    _view.ClearInputFields();
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa nhân viên do có hóa đơn liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnSelectEmployee(object sender, EventArgs e)
        {
            var selectedEmployee = _view.SelectedEmployee;
            if (selectedEmployee != null)
            {
                _view.MaNV = selectedEmployee.MaNV;
                _view.TenNV = selectedEmployee.TenNV;
                _view.NgaySinh = selectedEmployee.NgaySinh;
                _view.GioiTinh = selectedEmployee.GioiTinh;
                _view.DiaChi = selectedEmployee.DiaChi;
                _view.SoDienThoai = selectedEmployee.SoDienThoai;
                _view.VaiTro = selectedEmployee.VaiTro;
            }
        }
    }
}
