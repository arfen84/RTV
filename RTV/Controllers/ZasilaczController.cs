using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    public class ZasilaczController : Controller
    {
        Context db;

        public ZasilaczController()
        {
            db = new Context();
        }

        // GET: Zasilacz
        public ActionResult Zasilacze()
        {
            var zasilacze = db.Zasilacze.ToArray();
            return View(zasilacze);
        }

        // GET: Zasilacz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Zasilacz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zasilacz/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Zasilacz zasilacz = new Zasilacz();

                    zasilacz.Nazwa = Convert.ToString(collection["Nazwa"]);
                    zasilacz.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                    zasilacz.Marka = Convert.ToString(collection["Marka"]);
                    zasilacz.Opis = Convert.ToString(collection["Opis"]);
                    zasilacz.Chlodzenie = Convert.ToString(collection["Chlodzenie"]);
                    zasilacz.Modularne = Convert.ToString(collection["Modularne"]);
                    zasilacz.PFC = Convert.ToString(collection["PFC"]);
                    zasilacz.Sprawnosc = Convert.ToString(collection["Sprawnosc"]);
                    zasilacz.Standard = Convert.ToString(collection["Standard"]);
                    zasilacz.Wentylator = Convert.ToString(collection["Wentylator"]);
                    zasilacz.Stan = Convert.ToString(collection["Stan"]);

                    zasilacz.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                    zasilacz.Kategoria = "Zasilacze";

                    db.Zasilacze.Add(zasilacz);
                    db.SaveChanges();

                }
                return RedirectToAction("Zasilacze");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zasilacz/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Zasilacz ram = db.Zasilacze.Where(c => c.ZasilaczId == id).FirstOrDefault();
                    if (ram != null)
                        return View("~/Views/Zasilacz/Edit.cshtml", db.Zasilacze.Where(c => c.ZasilaczId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Zasilacze");
            }
            catch
            {
                return RedirectToAction("Zasilacze");
            }
        }

        // POST: Zasilacz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            try
            {
                if (us.Role == "Admin")
                {
                    Zasilacz zasilacz = db.Zasilacze.Find(id);

                    if (zasilacz != null)
                    {
                        zasilacz.Nazwa = Convert.ToString(collection["Nazwa"]);
                        zasilacz.Cena = Int32.Parse(Convert.ToString(collection["Cena"]));
                        zasilacz.Marka = Convert.ToString(collection["Marka"]);
                        zasilacz.Opis = Convert.ToString(collection["Opis"]);
                        zasilacz.Chlodzenie = Convert.ToString(collection["Chlodzenie"]);
                        zasilacz.Modularne = Convert.ToString(collection["Modularne"]);
                        zasilacz.PFC = Convert.ToString(collection["PFC"]);
                        zasilacz.Sprawnosc = Convert.ToString(collection["Sprawnosc"]);
                        zasilacz.Standard = Convert.ToString(collection["Standard"]);
                        zasilacz.Wentylator = Convert.ToString(collection["Wentylator"]);
                        zasilacz.Stan = Convert.ToString(collection["Stan"]);

                        zasilacz.Sprzedany = Boolean.Parse(collection["Sprzedany"]);
                        zasilacz.Kategoria = "Zasilacze";

                        db.Entry((Zasilacz)zasilacz).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Zasilacze");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zasilacz/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Zasilacz zasilacz = db.Zasilacze.Find(id);
                    if (zasilacz != null)
                        return View(zasilacz);
                }
                return RedirectToAction("Zasilacze");
            }
            catch
            {
                return RedirectToAction("Zasilacze");
            }
        }

        // POST: Zasilacz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Zasilacz zasilacz = db.Zasilacze.Find(id);
                    if (zasilacz != null)
                        db.Zasilacze.Remove(zasilacz);

                    db.SaveChanges();
                }
                return RedirectToAction("Zasilacze");
            }
            catch
            {
                return RedirectToAction("Zasilacze");
            }
        }
    }
}
