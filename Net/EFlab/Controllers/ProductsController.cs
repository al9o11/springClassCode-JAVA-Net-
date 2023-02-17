using EFlab.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFlab.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [HttpGet]
        public ActionResult EnterProducts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnterProducts(Product model)
        {
            var db = new EFlabEntities();
            db.Products.Add(model);
            db.SaveChanges();
            return View();
        }
        public ActionResult Show()
        {
            var db = new EFlabEntities();
            var products = db.Products.ToList();
            return View(products);
            
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var db = new EFlabEntities();
            var product = (from s in db.Products
                           where s.ID == id
                           select s).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product model)
        {
            var db = new EFlabEntities();
            var extstudent = (from s in db.Products
                              where s.ID == model.ID
                              select s).SingleOrDefault();
            extstudent.Name = model.Name;
            extstudent.Price = model.Price;
            extstudent.QTy = model.QTy;
            db.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}