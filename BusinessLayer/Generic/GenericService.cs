using DataAccess;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public List<T> GetList()
        {
            return _repository.GetList();
        }

        public T GetByID(int id)
        {
            return _repository.GetByID(id);
        }
        public virtual void EditDetails(T obj)
        {
            _repository.EditDetails(obj);
        }

        public IEnumerable<T> Search(string searchString)
        {
            return _repository.Search(searchString);
        }

        public void Export(int id)
        {
            _repository.Export(id);
        }

        public void Create(T obj)
        {
            _repository.Create(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public T GetUserByCredentials(string email, string password)
        {
            return _repository.GetUserByCredentials(email, password);
        }

        public void Save()
        {
            _repository.Save();
        }



    }
}
