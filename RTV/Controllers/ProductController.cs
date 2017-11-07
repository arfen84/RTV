using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    public class ProductController : Controller
    {
        Context db;

        public ProductController()
        {
            db = new Context();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Product.ToArray();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = db.Product.Where(x => x.ProductId == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Monitory()
        {
            var products = db.Product.Where(x=>x.Category=="Monitory").ToArray();
            return View(products);
        }

        // GET: Product/CreateMonitor
        public ActionResult CreateMonitor()
        {
            return View();
        }

        // POST: Product/CreateMonitor
        [HttpPost]
        public ActionResult CreateMonitor(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Product monitor = new Product();
                    monitor.ProductName = Convert.ToString(collection["ProductName"]);
                    monitor.Price = Int32.Parse(Convert.ToString(collection["Price"]));
                    monitor.Mark = Convert.ToString(collection["Mark"]);
                    monitor.Description = Convert.ToString(collection["Description"]);
                    monitor.rozdzielczosc = Convert.ToString(collection["rozdzielczosc"]);
                    monitor.przekatna = Int32.Parse(Convert.ToString(collection["przekatna"]));
                    monitor.czas_reakcji = Int32.Parse(Convert.ToString(collection["czas_reakcji"]));
                    monitor.jasnosc = Int32.Parse(Convert.ToString(collection["jasnosc"]));
                    monitor.Category = Convert.ToString(collection["Category"]);
                    monitor.technologiaPodswietlenia = Convert.ToString(collection["technologiaPodswietlenia"]);
                    monitor.stan = Convert.ToString(collection["stan"]);
                    db.Product.Add(monitor);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    return View(db.Product.Where(c => c.ProductId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Product monitor = db.Product.Where(x => x.ProductId == id).FirstOrDefault();
                    monitor.ProductName = Convert.ToString(collection["ProductName"]);
                    monitor.Price = Int32.Parse(Convert.ToString(collection["Price"]));
                    monitor.Mark = Convert.ToString(collection["Mark"]);
                    monitor.Description = Convert.ToString(collection["Description"]);
                    monitor.rozdzielczosc = Convert.ToString(collection["rozdzielczosc"]);
                    monitor.przekatna = Int32.Parse(Convert.ToString(collection["przekatna"]));
                    monitor.czas_reakcji = Int32.Parse(Convert.ToString(collection["czas_reakcji"]));
                    monitor.jasnosc = Int32.Parse(Convert.ToString(collection["jasnosc"]));
                    monitor.Category = Convert.ToString(collection["Category"]);
                    monitor.technologiaPodswietlenia = Convert.ToString(collection["technologiaPodswietlenia"]);
                    monitor.stan = Convert.ToString(collection["stan"]);

                    db.Entry(monitor).State = EntityState.Modified;
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    var prod = db.Product.Find(id);
                    return View(prod);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Product prod = db.Product.Find(id);
                    db.Product.Remove(prod);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
