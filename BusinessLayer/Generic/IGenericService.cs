using BusinessObjectModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IGenericService<T>
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
