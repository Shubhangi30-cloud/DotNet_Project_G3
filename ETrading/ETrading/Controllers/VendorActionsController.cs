using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ETrading.Models;

namespace ETrading.Controllers
{
    public class VendorActionsController : Controller
    {
        
        // GET: VendorActions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Vendor vendor)
        {
            using (E_TradingEntities context = new E_TradingEntities())
            {
                context.Vendors.Add(vendor);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Vendor vendor)
        {
            using (E_TradingEntities context = new E_TradingEntities())
            {
                bool IsUserValid = context.Vendors.Any(u => u.VendorName.ToLower() ==
                 vendor.VendorName.ToLower() && u.Password == vendor.Password);
                if (IsUserValid)
                {
                    FormsAuthentication.SetAuthCookie(vendor.VendorName, false);
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