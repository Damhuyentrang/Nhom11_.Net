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
    public class PreSalesInvoice
    {
        private readonly ISalesInvoiceView _view;
        private readonly RelationshipMapper _mapper;

        public PreSalesInvoice(ISalesInvoiceView view)
        {
            _view = view;
            _mapper = new RelationshipMapper();

            // Gắn các sự kiện từ giao diện
            _view.AddSalesInvoice += OnAddSalesInvoice;
            _view.UpdateSalesInvoice += OnUpdateSalesInvoice;
            _view.DeleteSalesInvoice += OnDeleteSalesInvoice;
            _view.SelectSalesInvoice += OnSelectSalesInvoice;
        }

        public void LoadAllSalesInvoices()
        {
            List<SalesInvoice> salesInvoices = _mapper.GetSalesInvoicesWithRelationships();
            _view.SalesInvoices = salesInvoices;
        }

        public void LoadReferenceData()
        {
            _view.SetCustomers(_mapper.GetCustomers());
            _view.SetEmployees(_mapper.GetEmployees());
        }

        private void OnAddSalesInvoice(object sender, EventArgs e)
        {
            var salesInvoice = new SalesInvoice
            {
                MaHDB = _view.MaHDB,
                MaKhach = _view.MaKhach,
                MaNV = _view.MaNV,
                NgayBan = _view.NgayBan,
                TongTien = _view.TongTien,
                TrangThaiDonHang = _view.TrangThaiDonHang
            };

            if (_mapper.AddSalesInvoice(salesInvoice))
            {
                LoadAllSalesInvoices();
                _view.ClearInputFields();
                MessageBox.Show("Thêm hóa đơn bán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateSalesInvoice(object sender, EventArgs e)
        {
            var salesInvoice = new SalesInvoice
            {
                MaHDB = _view.MaHDB,
                MaKhach = _view.MaKhach,
                MaNV = _view.MaNV,
                NgayBan = _view.NgayBan,
                TongTien = _view.TongTien,
                TrangThaiDonHang = _view.TrangThaiDonHang
            };

            if (_mapper.UpdateSalesInvoice(salesInvoice))
            {
                LoadAllSalesInvoices();
                _view.ClearInputFields();
                MessageBox.Show("Cập nhật hóa đơn bán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteSalesInvoice(object sender, EventArgs e)
        {
            var selectedInvoice = _view.SelectedSalesInvoice;
            if (selectedInvoice != null)
            {
                if (_mapper.DeleteSalesInvoice(selectedInvoice.MaHDB))
                {
                    LoadAllSalesInvoices();
                    _view.ClearInputFields();
                    MessageBox.Show("Xóa hóa đơn bán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa hóa đơn bán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnSelectSalesInvoice(object sender, EventArgs e)
        {
            var selectedInvoice = _view.SelectedSalesInvoice;
            if (selectedInvoice != null)
            {
                _view.MaHDB = selectedInvoice.MaHDB;
                _view.MaKhach = selectedInvoice.MaKhach;
                _view.MaNV = selectedInvoice.MaNV;
                _view.NgayBan = selectedInvoice.NgayBan;
                _view.TongTien = selectedInvoice.TongTien;
                _view.TrangThaiDonHang = selectedInvoice.TrangThaiDonHang;
            }
        }

        public List<Customer> GetCustomers()
        {
            return _mapper.GetCustomers();
        }

        public void LoadFilteredSalesInvoices(DateTime fromDate, DateTime toDate, string status)
        {
            var invoices = _mapper.GetSalesInvoicesWithRelationships();
            var filteredInvoices = invoices
                .Where(i => i.NgayBan >= fromDate && i.NgayBan <= toDate)
                .Where(i => status == "Tất cả" || i.TrangThaiDonHang == status)
                .ToList();

            _view.SalesInvoices = filteredInvoices;
        }
    }
}
