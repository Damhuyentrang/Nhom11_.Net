using System.Collections.Generic;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAllWithForeignKey(string foreignKeyTable, string foreignKeyId, string foreignKeyDisplayField);
        void Add(T entity);
        void Delete(object id);
        void Update(T entity);
        bool CheckForeignKeyExists(string foreignKeyTable, string foreignKeyId, object value);
    }
}
