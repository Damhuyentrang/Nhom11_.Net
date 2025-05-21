using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Database.Repositories;

namespace BTL_nhom11_marketPC.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly string tableName;//Lưu tên bảng trong cơ sở dữ liệu mà repository này sẽ làm việc
        private readonly string idPropertyName;//Lưu tên thuộc tính đại diện cho khóa chính (Mặc định là ID)

        public GenericRepository(string tableName, string idPropertyName = "Id")
        {
            this.tableName = tableName;
            this.idPropertyName = idPropertyName;
        }

        public List<T> GetAll()
        {
            List<T> items = new List<T>();
            using (var conn = DatabaseContext.GetConnection())//Dùng using để đảm bảo kết nối tự đóng
            {
                try
                {
                    string query = $"SELECT * FROM {tableName}";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T item = Activator.CreateInstance<T>();//Tạo 1 Instance của T bằng Activator.CreateInstance
                            var properties = typeof(T).GetProperties();//Lấy tất cả thuộc tính của T bằng GetProperties
                            foreach (var prop in properties)
                            {
                                if (reader.HasColumn(prop.Name) && !reader.IsDBNull(reader.GetOrdinal(prop.Name))) //Kiểm tra dữ liệu khớp với cột và có null không
                                {
                                    prop.SetValue(item, Convert.ChangeType(reader[prop.Name], prop.PropertyType));//Gán gtri csdl vào ttinh cua item sau khi chuyển kiểu dl
                                }
                            }
                            items.Add(item);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi truy vấn CSDL trong GetAll (bảng {tableName}): {ex.Message}", ex);
                }
            }
            DatabaseContext.CloseConnection();
            return items;
        }

        public List<T> GetAllWithForeignKey(string foreignKeyTable, string foreignKeyId, string foreignKeyDisplayField)
        {
            List<T> items = new List<T>();
            using (var conn = DatabaseContext.GetConnection())
            {
                try
                {
                    string query = $@"
                        SELECT t.*, f.{foreignKeyId}
                        FROM {tableName} t
                        LEFT JOIN {foreignKeyTable} f ON t.{foreignKeyId} = f.{foreignKeyId}";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T item = Activator.CreateInstance<T>();
                            var properties = typeof(T).GetProperties();
                            foreach (var prop in properties)
                            {
                                if (reader.HasColumn(prop.Name) && !reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(item, Convert.ChangeType(reader[prop.Name], prop.PropertyType));
                                }
                            }
                            items.Add(item);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi truy vấn CSDL trong GetAllWithForeignKey (bảng {tableName}): {ex.Message}", ex);
                }
            }
            DatabaseContext.CloseConnection();
            return items;
        }

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));//Kiểm tra đầu vào

            using (var conn = DatabaseContext.GetConnection())
            {
                try
                {
                    // Lấy tất cả các thuộc tính có thể ghi, bao gồm cả idPropertyName
                    var properties = typeof(T).GetProperties()
                        .Where(p => p.CanWrite)
                        .ToList();
                    var columns = string.Join(", ", properties.Select(p => p.Name));
                    var parameters = string.Join(", ", properties.Select(p => $"@{p.Name}"));
                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        foreach (var prop in properties)
                        {
                            var value = prop.GetValue(entity);
                            cmd.Parameters.AddWithValue($"@{prop.Name}", value ?? (object)DBNull.Value);
                        }
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            throw new Exception($"Không thể thêm vào {tableName}!");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi khi thêm dữ liệu vào {tableName}: {ex.Message}", ex);
                }
            }
            DatabaseContext.CloseConnection();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            using (var conn = DatabaseContext.GetConnection())
            {
                try
                {
                    var properties = typeof(T).GetProperties()
                        .Where(p => p.CanWrite)
                        .ToList();
                    var setClauses = string.Join(", ", properties.Where(p => p.Name != idPropertyName).Select(p => $"{p.Name} = @{p.Name}"));//Tạo danh sách các cột cần cập nhật
                    string query = $"UPDATE {tableName} SET {setClauses} WHERE {idPropertyName} = @{idPropertyName}";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        foreach (var prop in properties)
                        {
                            var value = prop.GetValue(entity);
                            cmd.Parameters.AddWithValue($"@{prop.Name}", value ?? (object)DBNull.Value);
                        }
                       
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            throw new Exception($"Không tìm thấy bản ghi trong {tableName} để cập nhật!");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi khi cập nhật dữ liệu trong {tableName}: {ex.Message}", ex);
                }
            }
            DatabaseContext.CloseConnection();
        }

        public void Delete(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            using (var conn = DatabaseContext.GetConnection())
            {
                try
                {
                    string query = $"DELETE FROM {tableName} WHERE {idPropertyName} = @{idPropertyName}";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue($"@{idPropertyName}", id);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            throw new Exception($"Không tìm thấy bản ghi trong {tableName} để xóa!");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi khi xóa dữ liệu trong {tableName}: {ex.Message}", ex);
                }
            }
            DatabaseContext.CloseConnection();
        }

        public bool CheckExists(object id)
        {
            using (var conn = DatabaseContext.GetConnection())
            {
                try
                {
                    string query = $"SELECT COUNT(*) FROM {tableName} WHERE {idPropertyName} = @{idPropertyName}";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue($"@{idPropertyName}", id);
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi khi kiểm tra tồn tại trong {tableName}: {ex.Message}", ex);
                }
            }
            DatabaseContext.CloseConnection();
            return false;
        }
        public bool CheckForeignKeyExists(string foreignKeyTable, string foreignKeyId, object value)
        {
            if (string.IsNullOrEmpty(foreignKeyTable) || string.IsNullOrEmpty(foreignKeyId) || value == null)
                return false;

            using (var conn = DatabaseContext.GetConnection())
            {
                try
                {
                    string query = $"SELECT COUNT(*) FROM {foreignKeyTable} WHERE {foreignKeyId} = @{foreignKeyId}";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue($"@{foreignKeyId}", value);
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Lỗi khi kiểm tra khóa ngoại trong {foreignKeyTable}: {ex.Message}", ex);
                }
            }
            DatabaseContext.CloseConnection();
            return false;
        }
    }


    public static class SqlDataReaderExtensions//kiểm tra xem một cột có tồn tại trong kết quả truy vấn hay không
    {
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }

}