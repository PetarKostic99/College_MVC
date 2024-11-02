using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcAppHelloWorld
{
    public interface IGenericAppService<TViewModel, TModel>
    {
        List<TViewModel> GetList();
        IEnumerable<TViewModel> Search(string searchString);
        void Export(int id);
        TViewModel GetByID(int id);
        void EditDetails(TViewModel viewModel);
        void Create(TViewModel viewModel);
        void Delete(int id);
        TViewModel GetUserByCredentials(string email, string password);
        void Save();
    }
}
