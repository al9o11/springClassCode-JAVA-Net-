using AssociationLab_EcomExaple_.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssociationLab_EcomExaple_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Customer model)
        {
            var db = new EcommerceEntities1();
            var extCustomer = (from c in db.Customers
                           where c.Name == model.Name
                           select c).SingleOrDefault();
            if(model.Name == extCustomer.Name && model.Password == extCustomer.Password)
            {
                Session["Name"] = extCustomer.Name; 
                return Redirect("/Customer/Dashboard");
            }
            else
            {
                TempData["msg"] = "User Not found";
                return View();
            }
             
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Customer model)
        {
            var db = new EcommerceEntities1();
            db.Customers.Add(model);
            db.SaveChanges();
            TempData["msg"] = "Account created sucessfully";
            return RedirectToAction("Index");
        }
    }
}