using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using MvcAppHelloWorld;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess;

namespace Controllers
{
    [Authorize(Roles = "Admin, Professor")]
    public class ProfessorController : GenericController<ProfessorViewModel, Professor>
    {
        private readonly IGenericAppService<ProfessorViewModel, Professor> _professorService;
        private readonly IGenericAppService<ProfessorQueryViewModel, ProfessorQueryModel> _professorQueryService;
        private readonly IGenericAppService<RoleViewModel, Role> _roleService;

        public ProfessorController(IGenericAppService<ProfessorViewModel, Professor> professorService,
            IGenericAppService<RoleViewModel, Role> roleService, IMapper mapper,
            IGenericAppService<ProfessorQueryViewModel, ProfessorQueryModel> professorQueryService) : base(professorService)
        {
            _professorService = professorService;
            _roleService = roleService;
            _professorQueryService = professorQueryService;
        }

        [Authorize(Roles = "Admin")]

        public override ActionResult Index()
        {
            var list = _professorQueryService.GetList();
            return View(list);
        }
        public override ActionResult Search(string searchString)
        {
            var content = _professorQueryService.Search(searchString);
            return View("Index", content);
        }
        public override ActionResult Save(ProfessorViewModel professor)
        {
            professor.UserRole = new List<UserRole>();

            UserRole professorRole = new UserRole
            {
                UserId = professor.UserId,
                RoleId = _roleService.GetList().FirstOrDefault(r => r.Name == "Professor").RoleId
            };
            professor.UserRole.Add(professorRole);

            _professorService.Create(professor);
            _professorService.Save();

            return RedirectToAction("Index");
        }
        public override ActionResult Details(int id)
        {
            ProfessorViewModel viewModel = _professorService.GetByID(id);
            viewModel.ReadOnly = true;
            viewModel.Title = "Details";
            viewModel.Disabled = "disabled";
            return View("Details", viewModel);
        }
        public override ActionResult Edit(int id)
        {
            ProfessorViewModel viewModel = _professorService.GetByID(id);
            viewModel.ReadOnly = false;
            viewModel.Title = "Edit";
            viewModel.Disabled = "";
            return View("Details", viewModel);
        }
        public ActionResult Profile()
        {
            ProfessorViewModel usersViewModel = _professorService.GetByID(_professorService.GetList().FirstOrDefault(u => u.Email == User.Identity.Name).UserId);

            return View("Profile", usersViewModel);
        }
    }
}