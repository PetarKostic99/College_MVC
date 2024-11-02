using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using MvcAppHelloWorld;
using System.Web.Mvc;
using System.Web.Security;

namespace Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : GenericController<RoleViewModel, Role>
    {
        private readonly IGenericAppService<RoleViewModel, Role> _roleService;

        public RolesController(IGenericAppService<RoleViewModel, Role> roleService, IMapper mapper) : base(roleService)
        {
            _roleService = roleService;
        }
        public override ActionResult Details(int id)
        {
            RoleViewModel viewModel = _roleService.GetByID(id);
            viewModel.ReadOnly = true;
            viewModel.Title = "Details";
            viewModel.Disabled = "disabled";
            return View("Details", viewModel);
        }
        public override ActionResult Edit(int id)
        {
            RoleViewModel viewModel = _roleService.GetByID(id);
            viewModel.ReadOnly = false;
            viewModel.Title = "Edit";
            viewModel.Disabled = "";
            return View("Details", viewModel);
        }
    }

}