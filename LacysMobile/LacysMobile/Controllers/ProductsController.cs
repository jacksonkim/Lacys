using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LacysMobile.Data;
using LacysMobile.Models;
using LacysMobile.Web.Models;
using LacysMobile.Web.Binders;


namespace LacysMobile.Web.Controllers
{
    public class ProductsController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();

        private UnitOfWork _uow = new UnitOfWork();

        public ActionResult Category(string itemType)
        {
            string headerName = "";
            List<Product> model = new List<Product>();
 
            switch (itemType)
            {
                case "WomenDress":
                    model = GetCategories(model, "WomenDress");
                    headerName = "Women's Dresses";
                    break;
                case "WomenCoats":
                    model = GetCategories(model, "WomenCoats");
                    headerName = "Women's Coats";
                    break;
                case "MenPants":
                    model = GetCategories(model, "MensPants");
                    headerName = "Men's Pants";
                    break;
                case "MenCoats":
                    model = GetCategories(model, "MenCoats");
                    headerName = "Men's Coats";
                    break;
                case "Handbags":
                    model = GetCategories(model, "Handbags");
                    headerName = "Handbags";
                    break;
                default: // "Sunglasses"
                    model = GetCategories(model, "Sunglasses");
                    headerName = "Sunglasses";
                    break;
            }

            ViewBag.Header = headerName;
            ViewBag.ItemCount = cart.ItemCount;
            return View(model);
        }

        private List<Product> GetCategories(List<Product> model, string category)
        {
            List<Product> womensDressList = this._uow.Products.GetAll().Where(p => p.ItemType == category).ToList();
            foreach (var product in womensDressList)
            {
                model.Add(new Product
                {
                    Name = product.Name,
                    ImageName = product.ImageName,
                    ProductID = product.ProductID,
                    Description = product.Description,
                    SellingPrice = product.SellingPrice
                });
            }

            return model;
        }

        public ActionResult Product(int id)
        {
            Product model = this._uow.Products.GetById(id);

            // read review
            List<ProductReview> reviewList = new List<ProductReview>();
            reviewList = this._uow.ProductReviews.GetAll().Where(r => r.ProductFK == id).ToList();

            foreach (var review in reviewList)
            {
                review.Date = review.ReviewDate.ToShortDateString();
            }

            ViewBag.ReviewModel = reviewList;

            ViewBag.Header = model.Name;
            ViewBag.ItemCount = cart.ItemCount;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddToCart(FormCollection product)
        {
            int productId = Convert.ToInt32(product["productId"]);
            int productQuantity = Convert.ToInt32(product["productQuantity"]);
            decimal sellingPrice = Convert.ToDecimal(product["sellingPrice"]);
            string productName = product["productName"];

            cart.AddShoppingCartItem(productId, productQuantity, sellingPrice, productName);
            return RedirectToAction("Product", new { id = productId });           
        } 


    }
}
