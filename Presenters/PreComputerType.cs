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
    public class PreComputerType
    {
        private readonly IComputerTypeView _view;
        private readonly RelationshipMapper _mapper;

        public PreComputerType(IComputerTypeView view)
        {
            _view = view;
            _mapper = new RelationshipMapper();

            // Gắn các sự kiện từ giao diện
            _view.AddComputerType += OnAddComputerType;
            _view.UpdateComputerType += OnUpdateComputerType;
            _view.DeleteComputerType += OnDeleteComputerType;
            _view.SelectComputerType += OnSelectComputerType;
        }

        public void LoadAllComputerTypes()
        {
            List<ComputerType> computerTypes = _mapper.GetComputerTypesWithRelationships();
            _view.SetComputerTypeList(computerTypes);
        }

        private void OnAddComputerType(object sender, EventArgs e)
        {
            var computerType = new ComputerType
            {
                MaLoaiMay = _view.MaLoaiMay,
                TenLoaiMay = _view.TenLoaiMay
            };

            if (_mapper.AddComputerType(computerType))
            {
                LoadAllComputerTypes(); // Tải lại danh sách sau khi thêm
                _view.ClearInputFields();
            }
            else
            {
                MessageBox.Show("Không thể thêm loại máy tính. Vui lòng kiểm tra mã loại máy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateComputerType(object sender, EventArgs e)
        {
            var computerType = new ComputerType
            {
                MaLoaiMay = _view.MaLoaiMay,
                TenLoaiMay = _view.TenLoaiMay
            };

            if (_mapper.UpdateComputerType(computerType))
            {
                LoadAllComputerTypes(); // Tải lại danh sách sau khi sửa
                _view.ClearInputFields();
            }
            else
            {
                MessageBox.Show("Không thể cập nhật loại máy tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteComputerType(object sender, EventArgs e)
        {
            var selectedComputerType = _view.SelectedComputertype;
            if (selectedComputerType != null)
            {
                if (_mapper.DeleteComputerType(selectedComputerType.MaLoaiMay))
                {
                    LoadAllComputerTypes(); // Tải lại danh sách sau khi xóa
                    _view.ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Không thể xóa loại máy tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnSelectComputerType(object sender, EventArgs e)
        {
            var selectedComputerType = _view.SelectedComputertype;
            if (selectedComputerType != null)
            {
                _view.MaLoaiMay = selectedComputerType.MaLoaiMay;
                _view.TenLoaiMay = selectedComputerType.TenLoaiMay;
            }
        }
    }
}
