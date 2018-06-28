using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    public class RAMController : Controller
    {
        Context db;

        public RAMController()
        {
            db = new Context();
        }

        // GET: RAM
        public ActionResult Pamieci()
        {
            var ram = db.RAM.ToArray();
            return View(ram);
        }

        // GET: RAM/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RAM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RAM/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    RAM ram = new RAM();

                    ram.Nazwa = Convert.ToString(collection["Nazwa"]);
                    ram.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    ram.Marka = Convert.ToString(collection["Marka"]);
                    ram.Opis = Convert.ToString(collection["Opis"]);
                    ram.Chlodzenie = Boolean.Parse(collection["Chlodzenie"]);
                    ram.Czestotliwosc = Int32.Parse(Convert.ToString(collection["Czestotliwosc"]));
                    ram.Moduly = Int32.Parse(Convert.ToString(collection["Moduly"]));
                    ram.Napiecie = float.Parse(Convert.ToString(collection["Napiecie"]));
                    ram.Typ = Convert.ToString(collection["Typ"]);
                    ram.Opoznienie = Int32.Parse(Convert.ToString(collection["Opoznienie"]));
                    ram.Pojemnosc = Int32.Parse(Convert.ToString(collection["Pojemnosc"]));
                    ram.Stan = Convert.ToString(collection["Stan"]);

                    ram.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                    ram.Kategoria = "Pamieci";

                    db.RAM.Add(ram);
                    db.SaveChanges();

                }
                return RedirectToAction("Pamieci");
            }
            catch
            {
                return View();
            }
        }

        // GET: RAM/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    RAM ram = db.RAM.Where(c => c.RAMId == id).FirstOrDefault();
                    if (ram != null)
                        return View("~/Views/RAM/Edit.cshtml", db.RAM.Where(c => c.RAMId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Pamieci");
            }
            catch
            {
                return RedirectToAction("Pamieci");
            }
        }

        // POST: RAM/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    RAM ram = db.RAM.Find(id);
                    if (ram != null)
                    {
                        ram.Nazwa = Convert.ToString(collection["Nazwa"]);
                        ram.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                        ram.Marka = Convert.ToString(collection["Marka"]);
                        ram.Opis = Convert.ToString(collection["Opis"]);
                        ram.Chlodzenie = Boolean.Parse(collection["Chlodzenie"].Split(',')[0]);
                        ram.Czestotliwosc = Int32.Parse(Convert.ToString(collection["Czestotliwosc"]));
                        ram.Moduly = Int32.Parse(Convert.ToString(collection["Moduly"]));
                        ram.Napiecie = float.Parse(Convert.ToString(collection["Napiecie"]));
                        ram.Typ = Convert.ToString(collection["Typ"]);
                        ram.Opoznienie = Int32.Parse(Convert.ToString(collection["Opoznienie"]));
                        ram.Pojemnosc = Int32.Parse(Convert.ToString(collection["Pojemnosc"]));
                        ram.Stan = Convert.ToString(collection["Stan"]);

                        ram.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                        ram.Kategoria = "Pamieci";

                        db.Entry((RAM)ram).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Pamieci");
            }
            catch
            {
                return View();
            }
        }

        // GET: RAM/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    RAM ram = db.RAM.Find(id);
                    if (ram != null)
                        return View(ram);
                }
                return RedirectToAction("Pamieci");
            }
            catch
            {
                return RedirectToAction("Pamieci");
            }
        }

        // POST: RAM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    RAM ram = db.RAM.Find(id);
                    if (ram != null)
                        db.RAM.Remove(ram);

                    db.SaveChanges();
                }
                return RedirectToAction("Pamieci");
            }
            catch
            {
                return RedirectToAction("Pamieci");
            }
        }
        
    }
}
