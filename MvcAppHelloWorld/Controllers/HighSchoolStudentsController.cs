using BusinessObjectModel;
using DataAccess;
using MvcAppHelloWorld;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Controllers
{
    [Authorize(Roles = "HighSchool, Professor, Admin")]
    public class HighSchoolStudentsController : GenericController<HighSchoolViewModel, HighSchool>
    {
        private readonly IGenericAppService<HighSchoolViewModel, HighSchool> _highSchoolService;
        private readonly IGenericAppService<HighSchoolStudentsQueryViewModel, HighSchoolStudentsQueryModel> _highSchoolQuery;
        private readonly IGenericAppService<RoleViewModel, Role> _roleAppService;

        public HighSchoolStudentsController(IGenericAppService<HighSchoolViewModel, HighSchool> highSchoolService,
            IGenericAppService<RoleViewModel, Role> roleService,
            IGenericAppService<HighSchoolStudentsQueryViewModel, HighSchoolStudentsQueryModel> highSchoolQuery) : base(highSchoolService)
        {
            _highSchoolService = highSchoolService;
            _roleAppService = roleService;
            _highSchoolQuery = highSchoolQuery;
        }

        public override ActionResult Index()
        {
            var listOfHighSchoolStudents = _highSchoolQuery.GetList();
            return View("Index", listOfHighSchoolStudents);
        }

        public override ActionResult Search(string searchString)
        {
            var content = _highSchoolQuery.Search(searchString);
            return View("Index", content);
        }


        [Authorize(Roles = "Professor")]
        public override ActionResult Save(HighSchoolViewModel highSchool)
        {
            highSchool.UserRole = new List<UserRole>();

            UserRole userRole = new UserRole
            {
                UserId = highSchool.UserId,
                RoleId = _roleAppService.GetList().FirstOrDefault(ur => ur.Name == "HighSchool").RoleId
            };

            highSchool.UserRole.Add(userRole);

            _highSchoolService.Create(highSchool);
            _highSchoolService.Save();

            return RedirectToAction("Index");
        }

        public override ActionResult Details(int id)
        {
            HighSchoolViewModel viewModel = _highSchoolService.GetByID(id);
            viewModel.ReadOnly = true;
            viewModel.Title = "Details";
            viewModel.Disabled = "disabled";
            return View("Details", viewModel);
        }
        public override ActionResult Edit(int id)
        {
            HighSchoolViewModel viewModel = _highSchoolService.GetByID(id);
            viewModel.ReadOnly = false;
            viewModel.Title = "Edit";
            viewModel.Disabled = "";
            return View("Details", viewModel);
        }
        public ActionResult Profile()
        {
            HighSchoolViewModel usersViewModel = _highSchoolService.GetByID(_highSchoolService.GetList().FirstOrDefault(u => u.Email == User.Identity.Name).UserId);

            return View(usersViewModel);
        }

    }
}