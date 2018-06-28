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
    public class DrukarkaController : Controller
    {
        Context db;

        public DrukarkaController()
        {
            db = new Context();
        }

        // GET: Drukarka
        public ActionResult Drukarki()
        {
            var products = db.Drukarki.ToArray();
            return View("~/Views/Drukarka/Drukarki.cshtml",products);
        }

        // GET: Drukarka/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Drukarka/Create
        public ActionResult CreateDrukarka()
        { 
            return View("~/Views/Drukarka/CreateDrukarka.cshtml");
        }

        // POST: Drukarka/Create
        [HttpPost]
        public ActionResult CreateDrukarka(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Drukarka druk = new Drukarka();
                    druk.Nazwa = Convert.ToString(collection["Nazwa"]);
                    druk.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    druk.Marka = Convert.ToString(collection["Marka"]);
                    druk.Opis = Convert.ToString(collection["Opis"]);

                    druk.Kategoria = Convert.ToString(collection["Kategoria"]);
                    druk.Typ = Convert.ToString(collection["Typ"]);
                    druk.Stan = Convert.ToString(collection["Stan"]);
                    druk.Sprzedany = Boolean.Parse(collection["Sprzedany"]);

                    db.Drukarki.Add(druk);
                    //db.Monitors.Create();
                    db.SaveChanges();
                }

                return RedirectToAction("/Drukarki");
            }
            catch 
            {
                return View("~/Views/Drukarka/CreateDrukarka.cshtml");
            }
        }

        // GET: Drukarka/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Drukarka druk = db.Drukarki.Where(c => c.DrukarkaId == id).FirstOrDefault();
            if (druk != null)
                return View("~/Views/Drukarka/EditDrukarka.cshtml", db.Drukarki.Where(c => c.DrukarkaId == id).FirstOrDefault()); //return edit view


                }
                return RedirectToAction("/Drukarki");
            }
            catch
            {
                return RedirectToAction("/Drukarki");
            }
        }

        // POST: Drukarka/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Drukarka druk = db.Drukarki.Where(x => x.DrukarkaId == id).FirstOrDefault();
                    if (druk != null)
                    {
                        druk.Nazwa = Convert.ToString(collection["Nazwa"]);
                        druk.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                        druk.Marka = Convert.ToString(collection["Marka"]);
                        druk.Opis = Convert.ToString(collection["Opis"]);

                        druk.Kategoria = Convert.ToString(collection["Kategoria"]);
                        druk.Typ = Convert.ToString(collection["Typ"]);
                        druk.Stan = Convert.ToString(collection["Stan"]);
                        druk.Sprzedany = Boolean.Parse(collection["Sprzedany"]);

                        db.Entry(druk).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    

                }
                return RedirectToAction("/Drukarki");
            }
            catch
            {
                return View("~/Views/Drukarka/EditDrukarka.cshtml");
            }
        }

        // GET: Drukarka/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Drukarka druk = db.Drukarki.Find(id);
                    if (druk != null)
                        return View("~/Views/Drukarka/Delete.cshtml",druk);

                }
                return RedirectToAction("/Drukarki");
            }
            catch
            {
                return RedirectToAction("/Drukarki");
            }
        }

        // POST: Drukarka/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Drukarka druk = db.Drukarki.Find(id);
                    if (druk != null)
                        db.Drukarki.Remove(druk);

                    db.SaveChanges();
                }
                return RedirectToAction("/Drukarki");
            }
            catch
            {
                return View();
            }
        }
    }
}
