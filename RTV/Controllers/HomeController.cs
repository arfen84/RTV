using Microsoft.AspNet.Identity.EntityFramework;
using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RTV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var Role = new IdentityRole();
            //Role.Name = "Admin";
            //using (var db2 = new Context())
            //{
            //    db2.Roles.Add(Role);
            //    db2.SaveChanges();
            //}
            //Role = new IdentityRole();
            //Role.Name = "User";
            //using (var db2 = new Context())
            //{
            //    db2.Roles.Add(Role);
            //    db2.SaveChanges();
            //}
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Registration userr)
        {
            //if (ModelState.IsValid)  
            //{  
            if (IsValid(userr.Email, userr.Password))
            {
                FormsAuthentication.SetAuthCookie(userr.Email, true);
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(userr);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.Registration user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new Context())
                    {
                        var crypto = new SimpleCrypto.PBKDF2();
                        var encrypPass = crypto.Compute(user.Password);
                        var newUser = db.Registrations.Create();
                        newUser.Email = user.Email;
                        newUser.Password = encrypPass;
                        newUser.PasswordSalt = crypto.Salt;
                     
                        db.Registrations.Add(newUser);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new Context())
            {
                var user = db.Registrations.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }

        [CustomAuthorize]
        public ActionResult  Secret()
        {
            return View();
        }
    }
}