using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    public class GrafikaController : Controller
    {
        Context db;

        public GrafikaController()
        {
            db = new Context();
        }

        // GET: Grafika
        public ActionResult Graficzne()
        {
            var graficzne = db.Graficzne.ToArray();
            return View(graficzne);
        }

        // GET: Grafika/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Grafika/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grafika/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Grafika graf = new Grafika();

                    graf.Nazwa = Convert.ToString(collection["Nazwa"]);
                    graf.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    graf.Marka = Convert.ToString(collection["Marka"]);
                    graf.Opis = Convert.ToString(collection["Opis"]);
                    graf.Chipset = Convert.ToString(collection["Chipset"]);
                    graf.Laczenie = Convert.ToString(collection["Laczenie"]);
                    graf.ProducentChipsetu = Convert.ToString(collection["ProducentChipsetu"]);
                    graf.RodzajRAM = Convert.ToString(collection["RodzajRAM"]);
                    graf.RAM = Int32.Parse(Convert.ToString(collection["RAM"]));
                    graf.Standard = Convert.ToString(collection["Standard"]);
                    graf.Stan = Convert.ToString(collection["Stan"]);
                    graf.Szyna = Int32.Parse(Convert.ToString(collection["Szyna"]));
                    graf.Wyjscie = Convert.ToString(collection["Wyjscie"]);
                    graf.Zlacze = Convert.ToString(collection["Zlacze"]);
                    graf.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                    graf.Kategoria = "Graficzne";

                    db.Graficzne.Add(graf);
                    db.SaveChanges();

                }
                return RedirectToAction("Graficzne");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grafika/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Grafika graf = db.Graficzne.Where(c => c.GrafikaId == id).FirstOrDefault();
                    if (graf != null)
                        return View("~/Views/Grafika/Edit.cshtml", db.Graficzne.Where(c => c.GrafikaId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Graficzne");
            }
            catch
            {
                return RedirectToAction("Graficzne");
            }
        }

        // POST: Grafika/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Grafika graf = db.Graficzne.Where(x => x.GrafikaId == id).FirstOrDefault();
                    if (graf != null)
                    {
                        graf.Nazwa = Convert.ToString(collection["Nazwa"]);
                        graf.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                        graf.Marka = Convert.ToString(collection["Marka"]);
                        graf.Opis = Convert.ToString(collection["Opis"]);
                        graf.Chipset = Convert.ToString(collection["Chipset"]);
                        graf.Laczenie = Convert.ToString(collection["Laczenie"]);
                        graf.ProducentChipsetu = Convert.ToString(collection["ProducentChipsetu"]);
                        graf.RodzajRAM = Convert.ToString(collection["RodzajRAM"]);
                        graf.RAM = Int32.Parse(Convert.ToString(collection["RAM"]));
                        graf.Standard = Convert.ToString(collection["Standard"]);
                        graf.Stan = Convert.ToString(collection["Stan"]);
                        graf.Szyna = Int32.Parse(Convert.ToString(collection["Szyna"]));
                        graf.Wyjscie = Convert.ToString(collection["Wyjscie"]);
                        graf.Zlacze = Convert.ToString(collection["Zlacze"]);
                        graf.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                        graf.Kategoria = "Graficzne";

                        db.Entry((Grafika)graf).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Graficzne");
            }
            catch
            {
                return View();
            }
        }

        // GET: Grafika/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Grafika graf = db.Graficzne.Find(id);
                    if (graf != null)
                        return View(graf);
                }
                return RedirectToAction("Graficzne");
            }
            catch
            {
                return RedirectToAction("Graficzne");
            }
        }

        // POST: Grafika/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Grafika graf = db.Graficzne.Find(id);
                    if (graf != null)
                        db.Graficzne.Remove(graf);

                    db.SaveChanges();
                }
                return RedirectToAction("Graficzne");
            }
            catch
            {
                return View();
            }
        }
    }
}
