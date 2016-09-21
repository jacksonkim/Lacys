using LacysMobile.Data;
using LacysMobile.Models;
using LacysMobile.Web.Binders;
using LacysMobile.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacysMobile.Web
{
    public class EmployeeController : Controller
    {
        ShoppingCartModel cart = (ShoppingCartModel)CartModelBinder.getSession();

        private UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        public ActionResult EmployeePage()
        {
            ViewBag.ItemCount = cart.ItemCount;
            ViewBag.Header = "Employee Portal";

            // feedback read
            var feedbacksList = this._uow.Feedback.GetAll().Where(f => f.Responded == false);
            foreach (var feedback in feedbacksList)
            {
                feedback.Date = feedback.FeedbackDate.ToShortDateString();
            }

            List<Feedback> feedbackModel = feedbacksList.ToList();

            // orders read
            var ordersList = this._uow.Orders.GetAll();
            var groupedOdersList = ordersList.GroupBy(o => System.Data.Entity.DbFunctions.TruncateTime(o.ShipDate))
                                             .SelectMany(grp => grp.Select(items => new OrderGroupModel
                                             {
                                                 OrderCount = grp.Count(),
                                                 ShippingDate = System.Data.Entity.DbFunctions.TruncateTime(items.ShipDate).Value,
                                                 OrderItems = items.OrderItems.GroupBy(i => i.ProductFK)
                                                              .SelectMany(igrp => igrp.Select(itemsList => new OrderItemGroupModel
                                                                {
                                                                    ProductId = itemsList.ProductFK,
                                                                    Quantity = igrp.Sum(item => item.Quantity),
                                                                    Cost = igrp.Sum(item => item.Cost)
                                                                })).ToList()
                                             })).ToList();

            string DateFilter = null;

            if (groupedOdersList.Count() > 0)
            {
                DateFilter = groupedOdersList.FirstOrDefault().ShippingDate.ToShortDateString();
            }

            List<OrderGroupModel> filteredOrderList = new List<OrderGroupModel>();

            if (DateFilter != null)
            {
                int count = 0;

                foreach (var groupedOrder in groupedOdersList)
                {
                    groupedOrder.ShortDate = groupedOrder.ShippingDate.ToShortDateString();

                    if (groupedOrder.ShortDate == DateFilter)
                    {
                        if (count == 0)
                        {
                            OrderGroupModel orderGroup = new OrderGroupModel
                            {
                                OrderCount = groupedOrder.OrderCount,
                                ShortDate = DateFilter,
                                OrderItems = GetOrdersItems(groupedOdersList, DateFilter)
                            };

                            filteredOrderList.Add(orderGroup);
                            count++;
                        }
                    }
                    else
                    {
                        DateFilter = groupedOrder.ShortDate;
                        count = 0;
                        OrderGroupModel orderGroup = new OrderGroupModel
                        {
                            OrderCount = groupedOrder.OrderCount,
                            ShortDate = DateFilter,
                            OrderItems = GetOrdersItems(groupedOdersList, DateFilter)
                        };
                    }
                }
            }

            ViewData["Orders"] = filteredOrderList;

            return View(feedbackModel);
        }



        private List<OrderItemGroupModel> GetOrdersItems(List<OrderGroupModel> orders, string DateFilter)
        {
            List<OrderItemGroupModel> newOrderItems = new List<OrderItemGroupModel>();

            foreach (var order in orders)
            {
                order.ShortDate = order.ShippingDate.ToShortDateString();

                if (order.ShortDate == DateFilter)
                {
                    foreach (var item in order.OrderItems)
                    {
                        item.ProductName = this._uow.Products.GetById(item.ProductId).Name;
                        item.Cost = Math.Round(item.Cost, 2);
                        newOrderItems.Add(item);
                    }
                }
            }

            return newOrderItems;
        }

        public ActionResult RespondedToFeedback(int id)
        {
            Feedback backendFeedback = this._uow.Feedback.GetById(id);

            backendFeedback.Responded = true;
            backendFeedback.Date = backendFeedback.FeedbackDate.ToShortDateString();
            this._uow.Feedback.UpdateWithId(backendFeedback, id);
            this._uow.SaveChanges();
             
            ViewBag.ItemCount = cart.ItemCount;
            ViewBag.Header = "Employee Portal";

            return RedirectToAction("EmployeePage");
        }
    }
}