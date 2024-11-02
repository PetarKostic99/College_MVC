using BusinessLayer;
using BusinessObjectModel;
using MvcAppHelloWorld;
using System.Data;
using System.Web.Mvc;

namespace Controllers
{
    public class GenericController<TViewModel, TModel> : Controller where TModel : class where TViewModel :class
    {

        private IGenericAppService<TViewModel, TModel> _service;

        public GenericController(IGenericAppService<TViewModel, TModel> service)
        {
            _service = service;
        }

        
        public virtual ActionResult Index()
        {
            var studentList = _service.GetList();
            return View("Index", studentList);
        }

        public virtual ActionResult Edit(int id)
        {
            var student = _service.GetByID(id);
            return View("Details", student);
        }

        public virtual ActionResult Details(int id)
        {
            var student = _service.GetByID(id);
            return View("Details", student);
        }

        public virtual ActionResult EditDetails(TViewModel obj)
        {
            if(ModelState.IsValid)
            {
                _service.EditDetails(obj);
                _service.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Save (TViewModel obj)
        {
            //if (ModelState.IsValid)
            //{
                _service.Create(obj);
                _service.Save();
                return View("Details", obj);
            //}
            //return RedirectToAction("Create", obj);
        }

        public ActionResult Delete(int id)
        {
                _service.Delete(id);
                _service.Save();
                return RedirectToAction("Index");
        }

        public virtual ActionResult Search(string searchString)
        {
           var content = _service.Search(searchString);
            return View("Index", content);
        }

        public ActionResult Export(int id)
        {
            _service.Export(id);
            return RedirectToAction("Index"); 
        }

    }
}