using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface IGraphicsCardView
    {
        List<GraphicsCard> GraphicsCards { set; }
        GraphicsCard SelectedGraphicsCard { get; set; }
        string MaCard { get; set; }
        string TenCard { get; set; }

        void SetGraphicsCardList(List<GraphicsCard> graphicsCards);

        // Events for Presenter to handle
        event EventHandler AddGraphicsCard;
        event EventHandler UpdateGraphicsCard;
        event EventHandler DeleteGraphicsCard;
        event EventHandler SelectGraphicsCard;


        // Methods to control
        void ClearInputFields();
    }
}
