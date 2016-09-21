using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LacysMobile.Web.Models;

namespace LacysMobile.Web.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ShoppingCartModel cart = (ShoppingCartModel)controllerContext.HttpContext.Session[this.sessionKey];
            if (cart == null)
            {
                cart = new ShoppingCartModel();
                controllerContext.HttpContext.Session[this.sessionKey] = cart;
            }

            return cart;
        }

        public static object getSession()
        {
            return HttpContext.Current.Session["Cart"];
        }

    }
}