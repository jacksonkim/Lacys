using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using LacysMobile.Web.Models;
using LacysMobile.Web.Filters;
using LacysMobile.Data;
using WebMatrix.WebData;
using LacysMobile.Web.Binders;

namespace LacysMobile.Web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();

        private UnitOfWork _uow = new UnitOfWork();
        //
        // GET: /Account/Index
        // does not get used
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public ActionResult UpdateProfile()
        {
            var user = this._uow.Users.GetById(WebSecurity.CurrentUserId);

            UserModel model = new UserModel();

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Address = user.AddressLine1;
            model.City = user.City;
            model.State = user.StateProvince;
            model.Email = user.EmailAddress;
            model.Phone = user.PhoneNumber;
            model.Zip = user.PostalCode;

            ViewBag.Header = "Update Your Profile";
            ViewBag.ItemCount = cart.ItemCount;
            return View("UpdateProfile", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateProfile(UserModel model)
        {
            if (ModelState.IsValid)
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

                ViewBag.Header = "Profile Updated";
                ViewBag.ItemCount = cart.ItemCount;
                return View("AccountUpdated", model);
            }
            else
            {
                ViewBag.Header = "Update Your Profile";
                ViewBag.ItemCount = cart.ItemCount;
                return View("UpdateProfile", model);
            }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Header = "Account Sign In";
            ViewBag.ItemCount = cart.ItemCount;
            return View("SignIn");
        }

        //
        // POST: /Account/Login
        [Authorize]
        public ActionResult SuccessfulSignIn()
        {
            ViewBag.ItemCount = cart.ItemCount;
            return View("SuccessfulSignIn");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: false))
            {
                return RedirectToAction(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View("SignIn", model);
        }

        //
        // GET: /Account/LogOff
        [AllowAnonymous]
        public ActionResult Thanks()
        {
            ViewBag.ItemCount = cart.ItemCount;
            return View("Thanks");
        }

        public ActionResult LogOff()
        {
            if (WebSecurity.Initialized)
            {
                WebSecurity.Logout();
            }

            return RedirectToAction("Thanks");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.Header = "Account Registration";
            ViewBag.ItemCount = cart.ItemCount;
            return View();
        }

        //
        // POST: /Account/Register
        [Authorize]
        public ActionResult SuccessfulRegistration()
        {
            ViewBag.ItemCount = cart.ItemCount;
            return View("SuccessfulRegistration");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, propertyValues: new
                    {
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        UserName = model.UserName
                    });

                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction(returnUrl);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message.ToString());
                }
            }

            ViewBag.ItemCount = cart.ItemCount;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            ViewBag.Header = "Change Password";
            ViewBag.ItemCount = cart.ItemCount;
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, userIsOnline: true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            ViewBag.Header = "Password Changed";
            ViewBag.ItemCount = cart.ItemCount;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            ViewBag.ItemCount = cart.ItemCount;
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
