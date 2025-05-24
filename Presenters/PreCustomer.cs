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
    public class PreCustomer
    {
        private readonly ICustomerView _view;
        private readonly RelationshipMapper _mapper;

        public PreCustomer(ICustomerView view)
        {
            _view = view;
            _mapper = new RelationshipMapper();

            // Gắn các sự kiện từ giao diện
            _view.AddCustomer += OnAddCustomer;
            _view.UpdateCustomer += OnUpdateCustomer;
            _view.DeleteCustomer += OnDeleteCustomer;
            _view.SelectCustomer += OnSelectCustomer;
        }

        public void LoadAllCustomers()
        {
            _view.Customers = _mapper.GetCustomers();
        }

        private void OnAddCustomer(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                MaKhach = _view.MaKhach,
                TenKhach = _view.TenKhach,
                GioiTinh = _view.GioiTinh,
                NgaySinh = _view.NgaySinh,
                SoDienThoai = _view.SoDienThoai,
                DiaChi = _view.DiaChi,
                Email = _view.Email
            };

            if (_mapper.AddCustomer(customer)) 
            {
                LoadAllCustomers();
                _view.ClearInputFields();
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateCustomer(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                MaKhach = _view.MaKhach,
                TenKhach = _view.TenKhach,
                GioiTinh = _view.GioiTinh,
                NgaySinh = _view.NgaySinh,
                SoDienThoai = _view.SoDienThoai,
                DiaChi = _view.DiaChi,
                Email = _view.Email
            };

            if (_mapper.UpdateCustomer(customer)) 
            {
                LoadAllCustomers();
                _view.ClearInputFields();
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteCustomer(object sender, EventArgs e)
        {
            var selectedCustomer = _view.SelectedCustomer;
            if (selectedCustomer != null)
            {
                if (_mapper.DeleteCustomer(selectedCustomer.MaKhach)) 
                {
                    LoadAllCustomers();
                    _view.ClearInputFields();
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa khách hàng do có hóa đơn liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnSelectCustomer(object sender, EventArgs e)
        {
            var selectedCustomer = _view.SelectedCustomer;
            if (selectedCustomer != null)
            {
                _view.MaKhach = selectedCustomer.MaKhach;
                _view.TenKhach = selectedCustomer.TenKhach;
                _view.GioiTinh = selectedCustomer.GioiTinh;
                _view.NgaySinh = selectedCustomer.NgaySinh;
                _view.SoDienThoai = selectedCustomer.SoDienThoai;
                _view.DiaChi = selectedCustomer.DiaChi;
                _view.Email = selectedCustomer.Email;
            }
        }
    }
}
