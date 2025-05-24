using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreSalesInvoiceDetail
    {
        private readonly ISalesInvoiceDetailView _view;
        private readonly RelationshipMapper _mapper;

        public PreSalesInvoiceDetail(ISalesInvoiceDetailView view)
        {
            _view = view;
            _mapper = new RelationshipMapper();

            // Gắn các sự kiện từ giao diện
            _view.AddSalesInvoiceDetail += OnAddSalesInvoiceDetail;
            _view.UpdateSalesInvoiceDetail += OnUpdateSalesInvoiceDetail;
            _view.DeleteSalesInvoiceDetail += OnDeleteSalesInvoiceDetail;
            _view.SelectSalesInvoiceDetail += OnSelectSalesInvoiceDetail;
        }

        public void LoadSalesInvoiceDetails(string maHDB)
        {
            var details = _mapper.GetSalesInvoiceDetailsByMaHDB(maHDB);
            _view.SalesInvoiceDetails = details;
        }

        public void LoadReferenceData()
        {
            _view.SetComputers(_mapper.GetComputersWithRelationships());
            _view.SetPromotions(_mapper.GetPromotions());
        }

        private void OnAddSalesInvoiceDetail(object sender, EventArgs e)
        {
            // Kiểm tra số lượng tồn kho
            if (!_mapper.CheckInventory(_view.MaMay, _view.SoLuong))
            {
                MessageBox.Show("Số lượng tồn kho không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //decimal price = _mapper.GetComputersWithRelationships()
            //    .FirstOrDefault(c => c.MaMay == _view.MaMay)?.DonGia ?? 0;
            //decimal total = CalculateTotalAmount(_view.SoLuong, price, _view.MaKhuyenMai);

            string maCTHDBBase = "CTHDB" + _view.MaHDB;
            int nextSequence = _mapper.GetNextCTHDBSequence(_view.MaHDB); // Lấy số thứ tự tiếp theo
            string maCTHDB = $"{maCTHDBBase}{nextSequence:D3}";

            var detail = new SalesInvoiceDetail
            {
                MaCTHDB = maCTHDB,
                MaHDB = _view.MaHDB,
                MaMay = _view.MaMay,
                SoLuong = _view.SoLuong,
                GiaBan = _view.GiaBan,
                ThanhTien = _view.ThanhTien,
                MaKhuyenMai = _view.MaKhuyenMai,
            };

            if (_mapper.AddSalesInvoiceDetail(detail))
            {
                _mapper.UpdateInventory(_view.MaMay, _view.SoLuong);
                LoadSalesInvoiceDetails(_view.MaHDB);
                UpdateInvoiceTotal(_view.MaHDB);
                _view.ClearInputFields();
                MessageBox.Show("Thêm chi tiết hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể thêm chi tiết hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateSalesInvoiceDetail(object sender, EventArgs e)
        {
            var originalDetail = _view.SelectedSalesInvoiceDetail;
            if (originalDetail == null)
            {
                MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //decimal price = _mapper.GetComputersWithRelationships()
            //    .FirstOrDefault(c => c.MaMay == _view.MaMay)?.DonGia ?? 0;
            //decimal total = CalculateTotalAmount(_view.SoLuong, price, _view.MaKhuyenMai);

            var detail = new SalesInvoiceDetail
            {
                MaCTHDB = originalDetail.MaCTHDB,
                MaHDB = _view.MaHDB,
                MaMay = _view.MaMay,
                SoLuong = _view.SoLuong,
                GiaBan = _view.GiaBan,
                ThanhTien = _view.ThanhTien,
                MaKhuyenMai = _view.MaKhuyenMai
            };

            int soLuongChange = _view.SoLuong - originalDetail.SoLuong;
            if (soLuongChange > 0 && !_mapper.CheckInventory(_view.MaMay, soLuongChange))
            {
                MessageBox.Show("Số lượng tồn kho không đủ để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_mapper.UpdateSalesInvoiceDetail(detail))
            {
                _mapper.UpdateInventory(_view.MaMay, soLuongChange); // Cập nhật tồn kho
                LoadSalesInvoiceDetails(_view.MaHDB);
                UpdateInvoiceTotal(_view.MaHDB);
                _view.ClearInputFields();
                MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteSalesInvoiceDetail(object sender, EventArgs e)
        {
            var selectedDetail = _view.SelectedSalesInvoiceDetail;
            if (selectedDetail != null)
            {
                if (_mapper.DeleteSalesInvoiceDetail(selectedDetail.MaCTHDB))
                {
                    _mapper.UpdateInventory(selectedDetail.MaMay, -selectedDetail.SoLuong); // Hoàn lại tồn kho
                    LoadSalesInvoiceDetails(_view.MaHDB);
                    UpdateInvoiceTotal(_view.MaHDB);
                    _view.ClearInputFields();
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa chi tiết hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnSelectSalesInvoiceDetail(object sender, EventArgs e)
        {
            var selectedDetail = _view.SelectedSalesInvoiceDetail;
            if (selectedDetail != null)
            {
                _view.MaCTHDB = selectedDetail.MaCTHDB;
                _view.MaHDB = selectedDetail.MaHDB;
                _view.MaMay = selectedDetail.MaMay;
                _view.SoLuong = selectedDetail.SoLuong;
                _view.GiaBan = selectedDetail.GiaBan;
                _view.ThanhTien = selectedDetail.ThanhTien;
                _view.MaKhuyenMai = selectedDetail.MaKhuyenMai;
            }
        }

        // Tính toán tự động thành tiền
        public decimal CalculateTotalAmount(int quantity, decimal price, string promotionId)
        {
            decimal total = quantity * price;

            if (!string.IsNullOrEmpty(promotionId))
            {
                var promotion = _mapper.GetPromotions().FirstOrDefault(p => p.MaKhuyenMai == promotionId);
                if (promotion != null && promotion.NgayBatDau <= DateTime.Today && promotion.NgayKetThuc >= DateTime.Today)
                {
                    total = total - total * (promotion.PhanTramGiam / 100m);
                }
            }

            return total;
        }

        public bool CheckPromotion(string promotionId)
        {
            if (string.IsNullOrEmpty(promotionId))
                return false;

            var promotion = _mapper.GetPromotions().FirstOrDefault(p => p.MaKhuyenMai == promotionId);
            if (promotion == null)
                return false;

            return promotion.NgayBatDau <= DateTime.Today && promotion.NgayKetThuc >= DateTime.Today;
        }


        //Cập nhật tổng tiền hóa đơn
        private void UpdateInvoiceTotal(string maHDB)
        {
            _mapper.UpdateInvoiceTotal(maHDB);
            decimal tongTien = _mapper.GetInvoiceTotal(maHDB);
            _view.TongTien = tongTien;
        }

        
    }
}