using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccess;
using BusinessObjectModel;

namespace MvcAppHelloWorld.Controllers
{
    public class RegisterController : Controller
    {
        
        // GET: Register
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(Users user)
        {
            using (var db = new TuxContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }
    }
}