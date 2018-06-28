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
    public class LaptopController : Controller
    {
        Context db;

        public LaptopController()
        {
            db = new Context();
        }

        // GET: Laptop
        public ActionResult Laptopy()
        {
            var laptopy = db.Laptops.ToArray();
            return View(laptopy);
        }

        // GET: Laptop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateLaptop()
        {
            return View();
        }

        // POST: Product/CreateLaptop
        [HttpPost]
        public ActionResult CreateLaptop(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Laptop laptop = new Laptop();
                    laptop.Nazwa = Convert.ToString(collection["Nazwa"]);
                    laptop.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    laptop.Marka = Convert.ToString(collection["Marka"]);
                    laptop.Opis = Convert.ToString(collection["Opis"]);
                    laptop.Rozdzielczosc = Convert.ToString(collection["Rozdzielczosc"]);
                    laptop.Przekatna = Int32.Parse(Convert.ToString(collection["Przekatna"]));
                    laptop.SeriaProcesora = Convert.ToString(collection["SeriaProcesora"]);
                    laptop.IloscRdzeni = Int32.Parse(Convert.ToString(collection["iloscRdzeni"]));
                    laptop.RAM = Int32.Parse(Convert.ToString(collection["RAM"]));
                    laptop.PamiecGrafika = Int32.Parse(Convert.ToString(collection["PamiecGrafika"]));
                    laptop.Stan = Convert.ToString(collection["Stan"]);
                    laptop.System = Convert.ToString(collection["System"]);
                    laptop.Zlacza = Convert.ToString(collection["Zlacza"]);
                    laptop.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                    laptop.Kategoria = "Laptopy";

                    laptop.Pojemnosc = Int32.Parse(Convert.ToString(collection["Pojemnosc"]));

                    db.Laptops.Add(laptop);
                    db.SaveChanges();
                }
                return RedirectToAction("Laptopy");
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Laptop laptop = db.Laptops.Where(c => c.LaptopId == id).FirstOrDefault();
                    if (laptop != null)
                        return View("~/Views/Laptop/Edit.cshtml", db.Laptops.Where(c => c.LaptopId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Laptopy");
            }
            catch
            {
                return RedirectToAction("Laptopy");
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
                    Laptop lap = db.Laptops.Where(x => x.LaptopId == id).FirstOrDefault();
                    if (lap != null)
                    {
                        var laptop = lap;

                        laptop.Nazwa = Convert.ToString(collection["Nazwa"]);
                        laptop.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                        laptop.Marka = Convert.ToString(collection["Marka"]);
                        laptop.Opis = Convert.ToString(collection["Opis"]);
                        laptop.Rozdzielczosc = Convert.ToString(collection["Rozdzielczosc"]);
                        laptop.Przekatna = Int32.Parse(Convert.ToString(collection["Przekatna"]));
                        laptop.SeriaProcesora = Convert.ToString(collection["SeriaProcesora"]);
                        laptop.IloscRdzeni = Int32.Parse(Convert.ToString(collection["iloscRdzeni"]));
                        laptop.RAM = Int32.Parse(Convert.ToString(collection["RAM"]));
                        laptop.PamiecGrafika = Int32.Parse(Convert.ToString(collection["PamiecGrafika"]));
                        laptop.Stan = Convert.ToString(collection["Stan"]);
                        laptop.System = Convert.ToString(collection["System"]);
                        laptop.Zlacza = Convert.ToString(collection["Zlacza"]);
                        laptop.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                        laptop.Kategoria = "Laptopy";

                        db.Entry(laptop).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Laptopy");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Laptop lap = db.Laptops.Find(id);
                    if (lap != null)
                        return View(lap);
                }
                return RedirectToAction("Laptopy");
            }
            catch
            {
                return RedirectToAction("Laptopy");
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
                    Laptop lap = db.Laptops.Find(id);
                    if (lap != null)
                        db.Laptops.Remove(lap);

                    db.SaveChanges();
                }
                return RedirectToAction("Laptopy");
            }
            catch
            {
                return View();
            }
        }
    }
}
