using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ETrading.Models;

namespace ETrading.Controllers
{
    public class AdminActionsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Form to Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            using (E_TradingEntities context = new E_TradingEntities())
            {
                bool IsUserValid = context.Admins.Any(u => u.AdminName.ToLower() ==
                 admin.AdminName.ToLower() && u.Password == admin.Password);
                if (IsUserValid)
                {
                    FormsAuthentication.SetAuthCookie(admin.AdminName, false);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}