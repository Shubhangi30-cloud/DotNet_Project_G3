using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ETrading.Models;

namespace ETrading.Controllers
{
    public class CustomerActionsController : Controller
    {
        E_TradingEntities db = new E_TradingEntities();
        

        // GET: CustomerActions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Customer customer)
        {
            using (E_TradingEntities context = new E_TradingEntities())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer model)
        {
            using (E_TradingEntities context = new E_TradingEntities())
            {
                bool IsUserValid = context.Customers.Any(u => u.CustomerName.ToLower() ==
                 model.CustomerName.ToLower() && u.Password == model.Password);
                if (IsUserValid)
                {
                    FormsAuthentication.SetAuthCookie(model.CustomerName, false);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }

        //public string BuyProduct(Product product)
        //{
        //    Customer c = new Customer();
        //    Product p = new Product();
        //    if (c.AccountBalance >= p.Price)
        //    {
        //        // User has enough money, deduct the product price from account balance
        //        c.AccountBalance -= p.Price;
        //        return "Thank you for shopping";
        //    }
        //    else
        //    {
        //        // Insufficient funds in the account
        //        return "Please update your account balance";
        //    }
        //}
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}