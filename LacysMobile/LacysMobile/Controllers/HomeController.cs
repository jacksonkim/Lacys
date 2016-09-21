using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LacysMobile.Data;
using LacysMobile.Models;
using LacysMobile.Web.Models;
using LacysMobile.Web.Binders;


namespace LacysMobile.Web.Controllers
{
    public class HomeController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();

        private UnitOfWork _uow = new UnitOfWork();

        public ActionResult Index(ShoppingCartModel cart)
        {
            var SpecialProductsUnshuffledList = _uow.Products.GetAll().Where(p => p.IsSpecial).Select(p => p).ToList();
            var SpecialProducts = SpecialProductsUnshuffledList.OrderBy(x => x.Description).ToList();

            var NewProductsUnshuffledList = _uow.Products.GetAll().Where(p => p.IsNew).Select(p => p).ToList();
            var NewProducts = NewProductsUnshuffledList.OrderBy(x => x.Description).ToList();

            ViewBag.Title = "Lacy's Home Page";
            ViewBag.Header = "Welcome to Lacy's";
            ViewBag.ItemCount = cart.ItemCount;

            Dictionary<string, List<Product>> productList = new Dictionary<string, List<Product>>();

            productList.Add("SpecialCarouselProducts", SpecialProducts);
            productList.Add("NewCarouselProducts", NewProducts);

            return View(productList);
        }

     }
}
