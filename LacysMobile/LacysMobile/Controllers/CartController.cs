using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LacysMobile.Web.Models;
using WebMatrix.WebData;
using LacysMobile.Web.Filters;
using LacysMobile.Data;
using LacysMobile.Models;
using System.Text.RegularExpressions;
using System.Diagnostics;
using LacysMobile.Web.Binders;

namespace LacysMobile.Web.Controllers
{
    public class CartController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();
        private UnitOfWork _uow = new UnitOfWork();

        // 1
        public ActionResult Checkout()
        {
            ViewBag.Header = "Checkout";
            ViewBag.ItemCount = cart.ItemCount;
            return View(cart);
        }

        public ActionResult Increment(int id)
        {
            var product = cart.GetShoppingCart.ShoppingCartItems.Where(i => i.ProductId == id);

            if (product.FirstOrDefault().Quantity == 6)
            {
                return RedirectToAction("Checkout");
            }

            cart.IncrementItem(id);

            return RedirectToAction("Checkout");
        }

        public ActionResult Decrement(int id)
        {
            var product = cart.GetShoppingCart.ShoppingCartItems.Where(i => i.ProductId == id);

            if (product.FirstOrDefault().Quantity == 1)
            {
                return RedirectToAction("Checkout");
            }

            cart.DecrementItem(id);
            return RedirectToAction("Checkout");
        }

        public ActionResult RemoveItem(int id)
        {
            cart.RemoveItem(id);
            return RedirectToAction("Checkout");
        }

        public ActionResult SignInOrRegister()
        {
            ViewBag.ItemCount = cart.ItemCount;

            if (cart.GetShoppingCart.ShoppingCartItems.Count() == 0)
            {
                return RedirectToAction("Checkout");
            }

            if (Request.IsAuthenticated)
            {
                ViewBag.Header = "Shipping";
                UserModel model = GetCurrentUserInfo();

                return View("Shipping", model);
            }

            ViewBag.Header = "Sign In or Register";

            return View();
        }

        [Authorize]
        public ActionResult SuccessfulSignIn()
        {
            ViewBag.ItemCount = cart.ItemCount;
            ViewBag.Header = "Shipping";
            UserModel model = GetCurrentUserInfo();

            return View("Shipping", model);
        }

        [AllowAnonymous]
        [HttpPost]
        [InitializeSimpleMembership]
        public ActionResult Login(CheckoutAccountModel model, string returnUrl)
        {

            if (WebSecurity.Login(model.UserName, model.Password, persistCookie: false))
            {
                return RedirectToAction(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View("SignInOrRegister", model);
        }

        [Authorize]
        public ActionResult SuccessfulRegistration()
        {
            ViewBag.ItemCount = cart.ItemCount;
            ViewBag.Header = "Shipping";

            return View("Shipping");
        }

        [AllowAnonymous]
        [HttpPost]
        [InitializeSimpleMembership]
        public ActionResult Register(CheckoutAccountModel model, string returnUrl)
        {

            try
            {
                WebSecurity.CreateUserAndAccount(model.RegisterUserName, model.RegisterPassword, propertyValues: new
                {
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    UserName = model.RegisterUserName
                });

                WebSecurity.Login(model.RegisterUserName, model.RegisterPassword);
                return RedirectToAction(returnUrl);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message.ToString());
            }

            ViewBag.ItemCount = cart.ItemCount;
            // If we got this far, something failed, redisplay form
            return View("SignInOrRegister", model);
        }

        [HttpPost]
        public ActionResult Payment(UserModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Header = "Payment";
                ViewBag.ItemCount = cart.ItemCount;
                cart.GetShoppingCart.ShipType = model.ShipType;

                SaveUserInfo(model);
                return View("Payment");
            }
            else
            {
                return View("Shipping", model);
            }
        }

        private void SaveUserInfo(UserModel model)
        {
            var user = this._uow.Users.GetById(WebSecurity.CurrentUserId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.AddressLine1 = model.Address;
            user.City = model.City;
            user.StateProvince = model.State;
            user.EmailAddress = model.Email;
            user.PhoneNumber = model.Phone;
            user.PostalCode = model.Zip;

            this._uow.Users.Update(user);
            this._uow.SaveChanges();

        }

        private UserModel GetCurrentUserInfo()
        {
            var user = this._uow.Users.GetById(WebSecurity.CurrentUserId);

            UserModel userInfo = new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.AddressLine1,
                City = user.City,
                State = user.StateProvince,
                Email = user.EmailAddress,
                Phone = user.PhoneNumber,
                Zip = user.PostalCode
            };

            return userInfo;
        }

        [HttpPost]
        public ActionResult SubmitOrder(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Header = "Order Confirmation";                

                // data integration
                Order newOrder = new Order();
                ShoppingCartSaleModel _cartSale = cart.GetShoppingCart;
                newOrder.CustFK = WebSecurity.CurrentUserId;
                newOrder.ShipDate = DateTime.Now;
                newOrder.ExpArrivalDate = DateTime.Now;
                newOrder.ShipType = _cartSale.ShipType;
                newOrder.PurchaseTotal = _cartSale.SubTotal;
                newOrder.ShipCost = _cartSale.ShippingCost;
                newOrder.OrderCost = _cartSale.OrderTotal;
                
                foreach( ProductModel frontItem in _cartSale.ShoppingCartItems)
                {
                    OrderItem backItem = new OrderItem();
                    backItem.OrderFK = newOrder.OrderID;
                    backItem.ProductFK = frontItem.ProductId;
                    backItem.Quantity = frontItem.Quantity;
                    backItem.Cost = frontItem.SalePrice;
                    newOrder.OrderItems.Add(backItem);
                }
                try
                {
                    this._uow.Orders.Add(newOrder);
                    this._uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }

                cart.ResetCart();
        
                ViewBag.ItemCount = cart.ItemCount;
                return View("ThankYou");
            }
            else
            {
                ViewBag.ItemCount = cart.ItemCount;
                return View("Payment", model);
            }
        }
    }
}
