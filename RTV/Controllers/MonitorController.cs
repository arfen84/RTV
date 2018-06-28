using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    [CustomAuthorize]
    public class MonitorController : Controller
    {
        Context db;

        public MonitorController()
        {
            db = new Context();
        }

        // GET: Monitor
        public ActionResult Monitory()
        {
            var products = db.Monitors.ToArray();
            return View("~/Views/Monitor/Monitory.cshtml", products);
        }

        //// GET: Monitor/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public ActionResult CreateMonitor()
        {
            return View("~/Views/Monitor/CreateMonitor.cshtml");
        }

        // GET: Monitor/Create
        [HttpPost]
        public ActionResult CreateMonitor(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Monitor monitor = new Monitor();
                    monitor.Nazwa = Convert.ToString(collection["Nazwa"]);
                    monitor.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    monitor.Marka = Convert.ToString(collection["Marka"]);
                    monitor.Opis = Convert.ToString(collection["Opis"]);
                    monitor.Rozdzielczosc = Convert.ToString(collection["Rozdzielczosc"]);
                    monitor.Przekatna = Int32.Parse(Convert.ToString(collection["Przekatna"]));
                    monitor.czas_reakcji = Int32.Parse(Convert.ToString(collection["czas_reakcji"]));
                    monitor.Jasnosc = Int32.Parse(Convert.ToString(collection["Jasnosc"]));
                    monitor.Kategoria = "Monitory";
                    monitor.Matryca = Convert.ToString(collection["Matryca"]);
                    monitor.Stan = Convert.ToString(collection["Stan"]);
                    monitor.Sprzedany = Boolean.Parse(collection["Sprzedany"]);

                    db.Monitors.Add(monitor);
                    //db.Monitors.Create();
                    db.SaveChanges();
                }

                return RedirectToAction("/Monitory");
            }
            catch 
            {
                return View("~/Views/Monitor/CreateMonitor.cshtml");
            }
        }

        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Monitor monitor = db.Monitors.Where(c => c.MonitorId == id).FirstOrDefault();
                    if (monitor != null)
                        return View("~/Views/Monitor/EditMonitor.cshtml", db.Monitors.Where(c => c.MonitorId == id).FirstOrDefault());
                }
                return RedirectToAction("/Monitory");
            }
            catch
            {
                return RedirectToAction("/Monitory");
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
                    Monitor mon = db.Monitors.Where(x => x.MonitorId == id).FirstOrDefault();
                    if (mon != null)
                    {
                        var monitor = mon;
                        monitor.Nazwa = Convert.ToString(collection["Nazwa"]);
                        monitor.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                        monitor.Marka = Convert.ToString(collection["Marka"]);
                        monitor.Opis = Convert.ToString(collection["Opis"]);
                        monitor.Rozdzielczosc = Convert.ToString(collection["Rozdzielczosc"]);
                        monitor.Przekatna = Int32.Parse(Convert.ToString(collection["Przekatna"]));
                        monitor.czas_reakcji = Int32.Parse(Convert.ToString(collection["czas_reakcji"]));
                        monitor.Jasnosc = Int32.Parse(Convert.ToString(collection["Jasnosc"]));
                        monitor.Kategoria = "Monitory";
                        monitor.Matryca = Convert.ToString(collection["Matryca"]);
                        monitor.Stan = Convert.ToString(collection["Stan"]);
                        monitor.Sprzedany = Boolean.Parse(collection["Sprzedany"]);

                        db.Entry(monitor).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("/Monitory");
            }
            catch
            {
                return View("~/Views/Monitor/EditMonitor.cshtml");
            }
        }

        // GET: Monitor/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Monitor mon = db.Monitors.Find(id);
                    if (mon != null)
                        return View("~/Views/Monitor/Delete.cshtml",mon);
                }
                return RedirectToAction("/Monitory");
            }
            catch
            {
                return RedirectToAction("/Monitory");
            }
        }

        // POST: Monitor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Monitor mon = db.Monitors.Find(id);
                    if (mon != null)
                        db.Monitors.Remove(mon);

                    db.SaveChanges();
                }
                return RedirectToAction("/Monitory");
            }
            catch
            {
                return View();
            }
        }
    }
}
