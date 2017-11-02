﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    [CustomAuthorize]
    public class UserController : Controller
    {
        Context db;
        public UserController() {
            db = new Context();
        }
        // GET: User
        public ActionResult Index()
        {
            var users = db.Registrations.ToArray();
            
            return View(users);
        }

        // GET: User/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: User/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    // TODO: Add insert logic here

                    Registration user = new Registration();
                    user.Password = Convert.ToString(collection["Password"]);
                    user.UserName = Convert.ToString(collection["UserName"]);
                    user.Role = Convert.ToString(collection["Role"]);
                    user.Email = Convert.ToString(collection["Email"]);

                    //IdentityRole rola = db.Roles.Where(c => c.Name == "Admin").FirstOrDefault();

                    //var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new Context()));
                    //if (!roleManager.RoleExists(Convert.ToString(collection["Role"])))
                    //{
                    //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    //    role.Name = Convert.ToString(collection["Role"]);
                    //    roleManager.Create(role);

                    //}

                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute(user.Password);
                    var newUser = db.Registrations.Create();
                    //newUser.Email = user.Email;
                    user.Password = encrypPass;
                    user.PasswordSalt = crypto.Salt;

                    db.Registrations.Add(user);
                    db.SaveChanges();
                    //await UserManager.AddToRoleAsync(user.UserId.ToString(), "Admin");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //private ApplicationUserManager _userManager;
        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    return View(db.Registrations.Where(c => c.UserId == id).FirstOrDefault()); //return edit view
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var us = User.Identity.Name;
            try
            {
                // TODO: Add update logic here
                var user = this.db.Registrations.Where(c => c.UserId == id).FirstOrDefault();
                user.UserName = Convert.ToString(collection["UserName"]);
                user.Email = Convert.ToString(collection["Email"]);
                user.Role = Convert.ToString(collection["Role"]);
                if (Convert.ToString(collection["Password"]) != String.Empty)
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    string pass = Convert.ToString(collection["Password"]);
                    var encrypPass = crypto.Compute(pass);
                    user.Password = encrypPass;
                    user.PasswordSalt = crypto.Salt;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var us = db.Registrations.Where(c => c.Email == User.Identity.Name).FirstOrDefault();

            try
            {
                if (us.Role == "Admin")
                {
                    Registration user = db.Registrations.Find(id);
                    return View(user);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Registration user = db.Registrations.Find(id);
                db.Registrations.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
