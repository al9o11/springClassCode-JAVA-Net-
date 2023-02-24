using AssociationLab_EcomExaple_.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace AssociationLab_EcomExaple_.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            var db = new EcommerceEntities1();
            db.Products.Add(model);
            db.SaveChanges();
            return View();
        }
        public ActionResult ViewProduct()
        {
            var db = new EcommerceEntities1();
            var products = db.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var db = new EcommerceEntities1();
            var product = (from p in db.Products
                           where p.Id == id
                           select p).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product model)
        {
            var db = new EcommerceEntities1();
            var extProduct = (from p in db.Products
                              where p.Id == model.Id
                              select p).SingleOrDefault();
            extProduct.Name = model.Name;
            extProduct.Seller = model.Seller;
            extProduct.Price = model.Price;
            extProduct.Quantity = model.Quantity;
            extProduct.CategoryID = model.CategoryID;
            db.SaveChanges();
            return RedirectToAction("ViewProduct");
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            var db = new EcommerceEntities1();
            var dlt = (from p in db.Products
                       where p.Id == id
                       select p).SingleOrDefault();
            if(dlt != null)
            {
                db.Products.Remove(dlt);
                db.SaveChanges();
            }
            return RedirectToAction("ViewProduct");
        }
    }
}