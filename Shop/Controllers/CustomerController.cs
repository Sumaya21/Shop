using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CustomerController : Controller
    {
        public List<CartDto> cart
        {
            get
            {
                if (Session["cart"] == null)
                {
                    Session["cart"] = new List<CartDto>();
                    return (List<CartDto>)Session["cart"];
                }
                return (List<CartDto>)Session["cart"];
            }
            set
            {
                Session["cart"] = value;
            }
        }
        // GET: Customer
        public ActionResult Index()
        {
            var db = new ProductSystemEntities2();
            var data=db.Products.ToList();
            return View(data);
        }


        public ActionResult AddToCart(int Id) 
        {

            var db = new ProductSystemEntities2();

            var product = db.Products.Find(Id);
            CartDto p = new CartDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            cart.Add(p);
            
            if (cart != null)
            {
                TempData["msg"] = "Product Added";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "Add Failed";
                return RedirectToAction("Index");
            }


        }
        public ActionResult Cart()
        {
            var data = cart.ToList();
            double total = 0;
            foreach (var item in cart)
            {
                total += Double.Parse(item.Price);
            }
            ViewBag.TotalPrice = total;

            return View(data);
        }

        public ActionResult DeleteCart(int Id)
        {
            var obj = cart.FirstOrDefault(item => item.Id == Id);
            if (obj != null)
            {
                cart.Remove(obj);
                TempData["msg"] = "Item Removed";
                return RedirectToAction("Cart");
            }
            else
            {
                TempData["msg"] = "Remove Failed";
                return RedirectToAction("Cart");
            }
        }

        public ActionResult Order()
        {
            var db = new ProductSystemEntities2();
            var o = new Oder()
            {
                CustomersId = (int)Session["Id"],
                Date = DateTime.Now
            };

            db.Oders.Add(o);
            db.SaveChanges();

            foreach (var item in cart)
            {
                var od = new OdersDetail()
                {
                    OdersId = o.Id,
                    ProductsId = item.Id,
                };

                db.OdersDetails.Add(od);
                db.SaveChanges();
            }

            cart.Clear();
            TempData["msg"] = "Order Completed";
            return RedirectToAction("Index");
        }

    }
}