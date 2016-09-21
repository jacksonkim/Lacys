using LacysMobile.Web.Binders;
using LacysMobile.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacysMobile.Web.Controllers
{
    public class CustomerController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();

        public ActionResult CustomerPage()
        {
            ViewBag.ItemCount = cart.ItemCount;
            ViewBag.Header = "Customer Portal";

            return View();
        }
	}
}