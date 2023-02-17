using EFlab.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFlab.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer model)
        {
            var db = new EFlabEntities();
            db.Customers.Add(model);
            db.SaveChanges();
            return View();
        }
        public ActionResult Show()
        {
            var db = new EFlabEntities();
            var customers = db.Customers.ToList();
            return View(customers);
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var db = new EFlabEntities();
            var customer = (from s in db.Customers
                           where s.ID == id
                           select s).SingleOrDefault();
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer model)
        {
            var db = new EFlabEntities();
            var extstudent = (from s in db.Customers
                              where s.ID == model.ID
                              select s).SingleOrDefault();
            extstudent.Phone = model.Phone;
            extstudent.Name = model.Name;
            extstudent.Password = model.Password;
            db.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}