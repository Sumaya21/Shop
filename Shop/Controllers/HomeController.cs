using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Signup() 
        {
        
        return View();
        }

        public ActionResult Signup(CustomersDto obj)
        {
            var db = new ProductSystemEntities2();

            if (ModelState.IsValid)
            {
                Customer c = new Customer()
                {
                    Name = obj.Name,
                    Email = obj.Email,
                    Password = obj.Password
                };



                db.Customers.Add(c);
                db.SaveChanges();
                TempData["msg"] = "User Added!";
                return RedirectToAction("Login", "Home");
            }

            else
            {
                TempData["msg"] = "Signup failed";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDto obj)
        {
            var db = new ProductSystemEntities2();

            var customers = (from c in db.Customers
                            where c.Email.Equals(obj.Email) &&
                            c.Password.Equals(obj.Password)
                            select c).SingleOrDefault();

            if (customers != null)
            {
                Session["Id"] = customers.Id;
                Session["Name"] = customers.Name;
                Session["Email"] = customers.Email;

                return RedirectToAction("Index", "Customer");
            }

            else
            {
                TempData["msg"] = "Login Failed!";
                return View(obj);
            }



        }
    }

    
}