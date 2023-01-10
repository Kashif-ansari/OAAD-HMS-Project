using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult login(Staff Staff)
        {
            HMSEntities lg = new HMSEntities();
            var count = lg.Staffs.Where(x => x.Name == Staff.Name && x.Password == Staff.Password).Count();
            if (count == 0)
            {
                ViewBag.Message = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(Staff.Name, false);
                return RedirectToAction("Index","Admin");
            }
            return View();
        }
    }
}