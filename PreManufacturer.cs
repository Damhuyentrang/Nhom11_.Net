using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Presenters
{
    namespace BTL_nhom11_marketPC.Presenters
    {
        public class ManufacturerPresenter
        {
            private readonly ManufacturerView _view;
            private readonly List<Manufacturer> _manufacturerList;
            private readonly string connectionString = "CuaHangPhanMemMayTinh";

            public ManufacturerPresenter(ManufacturerView view)
            {
                _view = view;
                _manufacturerList = new List<Manufacturer>();
            }

            public void LoadManufacturers()
            {
                _manufacturerList.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaHSX, TenHSX FROM HangSanXuat";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        _manufacturerList.Add(new Manufacturer
                        {
                            ManufacturerID = reader["MaHSX"].ToString(),
                            ManufacturerName = reader["TenHSX"].ToString()
                        });
                    }
                }

                _view.SetManufacturerList(_manufacturerList);
            }

            public void AddManufacturer()
            {
                var manufacturer = new Manufacturer
                {
                    ManufacturerID = _view.ManufacturerID,
                    ManufacturerName = _view.ManufacturerName
                };

                bool result = false;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO HangSanXuat (MaHSX, TenHSX) VALUES (@id, @name)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", manufacturer.ManufacturerID);
                    cmd.Parameters.AddWithValue("@name", manufacturer.ManufacturerName);

                    result = cmd.ExecuteNonQuery() > 0;
                }

                _view.ShowMessage(result ? "Added successfully." : "Failed to add.");
                LoadManufacturers();
            }
        }
    }
}