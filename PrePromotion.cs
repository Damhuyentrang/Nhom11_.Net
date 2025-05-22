using System;
using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PrePromotion
    {
        private readonly IViewPromotion view;
        private readonly IRepository<Promotion> repository;

        public PrePromotion(IViewPromotion view, IRepository<Promotion> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadPromotions()
        {
            var promotions = repository.GetAll(); 
            view.UpdatePromotionList(promotions); 
        }

    }
}
