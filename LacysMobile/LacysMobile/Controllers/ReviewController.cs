using LacysMobile.Data;
using LacysMobile.Models;
using LacysMobile.Web.Binders;
using LacysMobile.Web.Filters;
using LacysMobile.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace LacysMobile.Web.Controllers
{
    public class ReviewController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();

        private UnitOfWork _uow = new UnitOfWork();

        // 2 write review
        [HttpGet]
        [Authorize]
        public ActionResult ProductReview()
        {
            ViewBag.ItemCount = cart.ItemCount;
            ViewBag.Header = "Review " + this._uow.Products.GetById(ReviewModelProductId.ProductId).Name;
            return View();
        }

        // 3 write review
        [Authorize]
        public ActionResult SuccessfulReview(ReviewModel model)
        {
            if (Request.IsAuthenticated && ModelState.IsValid)
            {
                // data integration
                ProductReview newReview = new ProductReview();
                newReview.ProductFK = ReviewModelProductId.ProductId;
                newReview.Score = Convert.ToInt32(model.Score);
                newReview.UserFK = WebSecurity.CurrentUserId;
                newReview.ReviewDate = DateTime.Now;
                newReview.Comments = model.Comments;
                this._uow.ProductReviews.Add(newReview);
                this._uow.SaveChanges();

                ViewBag.ItemCount = cart.ItemCount;
                ViewBag.Header = "Review";
                ViewBag.ProductName = this._uow.Products.GetById(ReviewModelProductId.ProductId).Name;

                return View();
            }

            ViewBag.ItemCount = cart.ItemCount;
            ViewBag.Header = "Sign In or Register";

            return View("ProductReview", model);
        }

        // 1 write review
        public ActionResult SignInOrRegister(int id)
        {
            // set global
            ReviewModelProductId.ProductId = id;

            ViewBag.ItemCount = cart.ItemCount;

            if (Request.IsAuthenticated)
            {
                ViewBag.Header = "Review";
                return View("ProductReview");
            }

            ViewBag.Header = "Sign In or Register";
            return View();
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

	}
}