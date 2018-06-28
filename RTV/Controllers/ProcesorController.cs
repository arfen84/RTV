using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    public class ProcesorController : Controller
    {
        Context db;

        public ProcesorController()
        {
            db = new Context();
        }

        // GET: Procesor
        public ActionResult Procesory()
        {
            var procesory = db.Procesory.ToArray();
            return View(procesory);
        }

        // GET: Procesor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Procesor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procesor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Procesor procesor = new Procesor();

                    procesor.Nazwa = Convert.ToString(collection["Nazwa"]);
                    procesor.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    procesor.Marka = Convert.ToString(collection["Marka"]);
                    procesor.Opis = Convert.ToString(collection["Opis"]);
                    procesor.Chlodzenie = Boolean.Parse(collection["Chlodzenie"]);
                    procesor.Gniazdo = Convert.ToString(collection["Gniazdo"]);
                    procesor.Linia = Convert.ToString(collection["Linia"]);
                    procesor.Mnoznik = Boolean.Parse(collection["Mnoznik"]);
                    procesor.Rdzenie = Int32.Parse(Convert.ToString(collection["Rdzenie"]));
                    procesor.Stan = Convert.ToString(collection["Stan"]);

                    procesor.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                    procesor.Kategoria = "Procesory";

                    db.Procesory.Add(procesor);
                    db.SaveChanges();

                }
                return RedirectToAction("Procesory");
            }
            catch
            {
                return View();
            }
        }

        // GET: Procesor/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Procesor proc = db.Procesory.Where(c => c.ProcesorId == id).FirstOrDefault();
                    if (proc != null)
                        return View("~/Views/Procesor/Edit.cshtml", db.Procesory.Where(c => c.ProcesorId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Procesory");
            }
            catch
            {
                return RedirectToAction("Procesory");
            }
        }

        // POST: Procesor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Procesor procesor = db.Procesory.Find(id);

                    procesor.Nazwa = Convert.ToString(collection["Nazwa"]);
                    procesor.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    procesor.Marka = Convert.ToString(collection["Marka"]);
                    procesor.Opis = Convert.ToString(collection["Opis"]);
                    procesor.Chlodzenie = Convert.ToBoolean(collection["Chlodzenie"]);
                    procesor.Gniazdo = Convert.ToString(collection["Gniazdo"]);
                    procesor.Linia = Convert.ToString(collection["Linia"]);
                    procesor.Mnoznik = Convert.ToBoolean(collection["Mnoznik"]);
                    procesor.Rdzenie = Int32.Parse(Convert.ToString(collection["Rdzenie"]));
                    procesor.Stan = Convert.ToString(collection["Stan"]);

                    procesor.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                    procesor.Kategoria = "Procesory";

                    db.Entry((Procesor)procesor).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Procesory");
            }
            catch
            {
                return View();
            }
        }

        // GET: Procesor/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Procesor proc = db.Procesory.Find(id);
                    if (proc != null)
                        return View(proc);
                }
                return RedirectToAction("Procesory");
            }
            catch
            {
                return RedirectToAction("Procesory");
            }
        }

        // POST: Procesor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Procesor proc = db.Procesory.Find(id);
                    if (proc != null)
                        db.Procesory.Remove(proc);

                    db.SaveChanges();
                }
                return RedirectToAction("Procesory");
            }
            catch
            {
                return View();
            }
        }
    }
}
