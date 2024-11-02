using AutoMapper;
using BusinessLayer;
using System.Collections.Generic;
using System.Linq;

namespace MvcAppHelloWorld
{
    public class GenericAppService<TViewModel, TModel> : IGenericAppService<TViewModel, TModel> where TViewModel : class where TModel : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<TModel> _genericService;

        public GenericAppService(IGenericService<TModel> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }


        public List<TViewModel> GetList()
        {
            //Because we want to return list of users from db, we need to map ViewModel with DomenModel

            List<TModel> models = _genericService.GetList(); // instantiating domen model and using service method from bussines layer service
            List<TViewModel> viewModels = _mapper.Map<List<TViewModel>>(models); // Mapping in direction ViewModel->DomenModel (_mapper.Map<What we map>(with what we map))
            return viewModels;
        }

        public TViewModel GetByID(int id)
        {
            TViewModel model = _mapper.Map<TViewModel>(_genericService.GetByID(id));
            return model;
        }
        public void EditDetails(TViewModel viewModel)
        {
            TModel model = _mapper.Map<TModel>(viewModel);
            _genericService.EditDetails(model);
        }

        public virtual IEnumerable<TViewModel> Search(string searchString)
        {
            List<TModel> models = _genericService.Search(searchString).ToList();
            List<TViewModel> viewModels = _mapper.Map<List<TViewModel>>(models);
            return viewModels;
        }

        public void Export(int id)
        {
            _genericService.Export(id);
        }

        public virtual void Create(TViewModel viewModel)
        {
            //In ths situation we need to map in other directoin. In this case we write data in db. So we need to map DomenModel with ViewModel

            TModel businessObjectModel = _mapper.Map<TModel>(viewModel);// Mapping in direction DomenModel->ViewModel (_mapper.Map<What we map>(with what we map))
            _genericService.Create(businessObjectModel);
        }

        public void Delete(int id)
        {
            _genericService.Delete(id);
        }

        public TViewModel GetUserByCredentials(string email, string password)
        {
            var user = _genericService.GetUserByCredentials(email, password);
            if (user != null)
            {
                TViewModel existingUser = _mapper.Map<TViewModel>(user);
                return existingUser;
            }
            return null;
        }

        public void Save()
        {
            _genericService.Save();
        }
    }
}