using RTV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RTV.Controllers
{
    [CustomAuthorize]
    public class ProductController : Controller
    {
        Context db;

        public ProductController()
        {
            db = new Context();
        }

        // GET: Product
        public ActionResult Index()
        {
            //var products = db.Products.ToArray();
            ProductViewModel allProducts = new ProductViewModel();
            allProducts.Monitory = db.Monitors.ToList();
            allProducts.Laptopy = db.Laptops.ToList();
            allProducts.Drukarki = db.Drukarki.ToList();
            allProducts.Graficzne = db.Graficzne.ToList();
            allProducts.Pamieci = db.RAM.ToList();
            allProducts.Plyty = db.Plyty.ToList();
            allProducts.Procesory = db.Procesory.ToList();
            allProducts.Zasilacze = db.Zasilacze.ToList();

            return View(allProducts);
        }

        


    }
}
