using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAppHelloWorld;
using System.Web.Mvc;
using BusinessObjectModel;
using Microsoft.AspNet.Identity;

namespace Controllers
{
    public class UserController : GenericController<UsersViewModel, Users>
    {
        private readonly IGenericAppService<UsersViewModel, Users> _userAppService;
        private readonly IGenericAppService<RoleViewModel, Role> _roleAppService;


        public UserController(IGenericAppService<UsersViewModel, Users> userAppService, IGenericAppService<RoleViewModel, Role> roleAppService) :base(userAppService)
        {
            _userAppService = userAppService;
            _roleAppService = roleAppService;
        }

        public ActionResult Profile()
        {
            UsersViewModel usersViewModel = _userAppService.GetByID(_userAppService.GetList().FirstOrDefault(u => u.Email == User.Identity.Name).UserId);
            
            return View(usersViewModel);
        }
    }
}