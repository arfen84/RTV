using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    public class PlytaController : Controller
    {
        Context db;

        public PlytaController()
        {
            db = new Context();
        }

        // GET: Plyta
        public ActionResult Plyty()
        {
            var plyty = db.Plyty.ToArray();
            return View(plyty);
        }

        // GET: Plyta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Plyta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plyta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Plyta plyta = new Plyta();

                    plyta.Nazwa = Convert.ToString(collection["Nazwa"]);
                    plyta.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    plyta.Marka = Convert.ToString(collection["Marka"]);
                    plyta.Opis = Convert.ToString(collection["Opis"]);
                    plyta.Chipset = Convert.ToString(collection["Chipset"]);
                    plyta.Gniazdo = Convert.ToString(collection["Gniazdo"]);
                    plyta.GniazdoRAM = Convert.ToString(collection["GniazdoRAM"]);
                    plyta.CzestotliwoscRAM = Convert.ToString(collection["CzestotliwoscRAM"]);
                    plyta.PanelTylni = Convert.ToString(collection["PanelTylni"]);
                    plyta.Standard = Convert.ToString(collection["Standard"]);
                    plyta.Stan = Convert.ToString(collection["Stan"]);

                    plyta.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                    plyta.Kategoria = "Plyty";

                    db.Plyty.Add(plyta);
                    db.SaveChanges();

                }
                return RedirectToAction("Plyty");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plyta/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Plyta plyta = db.Plyty.Where(c => c.PlytaId == id).FirstOrDefault();
                    if (plyta != null)
                        return View("~/Views/Plyta/Edit.cshtml", db.Plyty.Where(c => c.PlytaId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Plyty");
            }
            catch
            {
                return RedirectToAction("Pytyly");
            }
        }

        // POST: Plyta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Plyta plyta = db.Plyty.Find(id);

                    plyta.Nazwa = Convert.ToString(collection["Nazwa"]);
                    plyta.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    plyta.Marka = Convert.ToString(collection["Marka"]);
                    plyta.Opis = Convert.ToString(collection["Opis"]);
                    plyta.Chipset = Convert.ToString(collection["Chipset"]);
                    plyta.Gniazdo = Convert.ToString(collection["Gniazdo"]);
                    plyta.GniazdoRAM = Convert.ToString(collection["GniazdoRAM"]);
                    plyta.CzestotliwoscRAM = Convert.ToString(collection["CzestotliwoscRAM"]);
                    plyta.PanelTylni = Convert.ToString(collection["PanelTylni"]);
                    plyta.Standard = Convert.ToString(collection["Standard"]);
                    plyta.Stan = Convert.ToString(collection["Stan"]);

                    db.Entry((Plyta)plyta).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Plyty");
            }
            catch
            {
                return View();
            }
        }
        

        // GET: Plyta/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Plyta plyta = db.Plyty.Find(id);
                    if (plyta != null)
                        return View(plyta);
                }
                return RedirectToAction("Plyty");
            }
            catch
            {
                return RedirectToAction("Plyty");
            }
        }

        // POST: Plyta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Plyta plyta = db.Plyty.Find(id);
                    if (plyta != null)
                        db.Plyty.Remove(plyta);

                    db.SaveChanges();
                }
                return RedirectToAction("Plyty");
            }
            catch
            {
                return View();
            }
        }
    }
}
