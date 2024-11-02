using BusinessObjectModel;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcAppHelloWorld.Controllers
{
    public class LoginController : Controller
    {
        private IGenericAppService<UsersViewModel, Users> _service;
        public LoginController(IGenericAppService<UsersViewModel, Users> service)
        {
            _service = service;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsersViewModel user)
        {
            var existingUser = _service.GetUserByCredentials(user.Email, user.Password);

            if (user != null)
            {
                var Ticket = new FormsAuthenticationTicket(user.Email, true, 3000);
                string Encrypt = FormsAuthentication.Encrypt(Ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                cookie.Expires = DateTime.Now.AddHours(3000);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                if (existingUser.UserRole.FirstOrDefault(ur => ur.Role.Name == "Admin") != null)
                {
                    return RedirectToAction("Index", "Admin");
                }
                if (existingUser.UserRole.FirstOrDefault(ur => ur.Role.Name == "Professor") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (existingUser.UserRole.FirstOrDefault(ur => ur.Role.Name == "College") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (existingUser.UserRole.FirstOrDefault(ur => ur.Role.Name == "HighSchol") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}