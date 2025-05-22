using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreSupplier
 {
     private IViewSupplier
         view;
     private string connectionString = "Data Source=.;Initial Catalog=CuaHangPhanMemMayTinh;Integrated Security=True";

     public PreSupplier(IViewSupplier
         view)
     {
         this.view = view;
         LoadSuppliers();
     }

     public void LoadSuppliers()
     {
         var suppliers = new List<Supplier>();
         using (SqlConnection conn = new SqlConnection(connectionString))
         {
             string query = "SELECT * FROM NhaCungCap";
             SqlCommand cmd = new SqlCommand(query, conn);
             conn.Open();
             SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 suppliers.Add(new Supplier
                 {
                     SupplierID = reader["MaNCC"].ToString(),
                     SupplierName = reader["TenNCC"].ToString(),
                     Address = reader["DiaChi"].ToString(),
                     PhoneNumber = reader["SoDienThoai"].ToString(),
                     Email = reader["Email"].ToString()
                 });
             }
         }

         view.SetSupplierList(suppliers);
     }

     public void AddSupplier()
     {
         try
         {
             using (SqlConnection conn = new SqlConnection(connectionString))
             {
                 string query = @"INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email)
                                  VALUES (@MaNCC, @TenNCC, @DiaChi, @SoDienThoai, @Email)";
                 SqlCommand cmd = new SqlCommand(query, conn);
                 cmd.Parameters.AddWithValue("@MaNCC", view.MaNCC);
                 cmd.Parameters.AddWithValue("@TenNCC", view.TenNCC);
                 cmd.Parameters.AddWithValue("@DiaChi", view.DiaChi);
                 cmd.Parameters.AddWithValue("@SoDienThoai", view.SoDienThoai);
                 cmd.Parameters.AddWithValue("@Email", view.Email);
                 conn.Open();
                 cmd.ExecuteNonQuery();
             }

             view.ShowMessage("Supplier added successfully.");
             LoadSuppliers();
         }
         catch (Exception ex)
         {
             view.ShowMessage("Error: " + ex.Message);
         }
     }

     public void DeleteSupplier()
     {
         try
         {
             using (SqlConnection conn = new SqlConnection(connectionString))
             {
                 string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                 SqlCommand cmd = new SqlCommand(query, conn);
                 cmd.Parameters.AddWithValue("@MaNCC", view.MaNCC);
                 conn.Open();
                 cmd.ExecuteNonQuery();
             }

             view.ShowMessage("Supplier deleted.");
             LoadSuppliers();
         }
         catch (Exception ex)
         {
             view.ShowMessage("Error: " + ex.Message);
         }
     }
 }
}
