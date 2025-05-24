using System;
using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PrePromotion
    {
        private readonly IViewPromotion _view;
        private readonly List<Promotion> _promotionList;

        public PrePromotion(IViewPromotion view, Database.Repositories.PromotionRepository repository)
        {
            _view = view;
            _promotionList = new List<Promotion>();
        }

        public void LoadPromotion()
        {
            _view.SetPromotionList(_promotionList);
        }

        public void AddPromotion()
        {
            var km = new Promotion
            {
                MaKhuyenMai = _view.MaKhuyenMai,
                TenKhuyenMai = _view.TenKhuyenMai,
                PhanTramGiam = _view.PhanTramGiam,
                NgayBatDau = _view.NgayBatDau,
                NgayKetThuc = _view.NgayKetThuc
            };

            _promotionList.Add(km);
            _view.ShowMessage("Thêm khuyến mãi thành công.");
            LoadPromotion();
        }

        internal void LoadPromotions()
        {
            throw new NotImplementedException();
        }
    }
}
