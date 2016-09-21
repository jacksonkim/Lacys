using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LacysMobile.Models;
using LacysMobile.Web.Models;
using LacysMobile.Data;
using System.Diagnostics;
using LacysMobile.Web.Binders;

namespace LacysMobile.Web.Controllers
{
    public class FeedbackController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();

        private UnitOfWork _uow = new UnitOfWork();

        public ActionResult FeedbackForm()
        {
            ViewBag.Header = "Feedback";
            ViewBag.ItemCount = cart.ItemCount;
            return View();
        }

        [HttpPost]
        public ActionResult FeedbackSubmit(FeedbackModels model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Header = "Feedback";
                ViewBag.ItemCount = cart.ItemCount;

                // data integration
                Feedback backendFeedback = new Feedback();
                backendFeedback.FirstName = model.FirstName;
                backendFeedback.LastName = model.LastName;
                backendFeedback.Email = model.Email;
                backendFeedback.Comments = model.Comments;
                backendFeedback.FeedbackDate = DateTime.Now;
                backendFeedback.Responded = false;
                try
                {
                    this._uow.Feedback.Add(backendFeedback);
                    this._uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }

                return View("FeedbackSuccess");
            }

            return View("FeedbackForm", model);
        }

    }
}
