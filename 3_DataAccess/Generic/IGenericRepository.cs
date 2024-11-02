using System.Collections.Generic;

namespace DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetList();
        IEnumerable<T> Search(string searchString);
        void Export(int id);
        T GetByID(int id);
        void EditDetails(T obj);
        void Create(T obj);
        void Delete(int id);
        T GetUserByCredentials(string email, string password);
        void Save();
    }
}
