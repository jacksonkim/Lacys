using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacysMobile.Web.Models
{
    public class ShoppingCartModel
    {
        private ShoppingCartSaleModel _cartSale;

        public ShoppingCartModel()
        {
            _cartSale = new ShoppingCartSaleModel();
        }

        public int ItemCount
        {
            get
            {
                int itemCount = 0;
                foreach (var item in _cartSale.ShoppingCartItems)
                {
                    itemCount += item.Quantity;
                }

                return itemCount;
            }
        }

        public decimal CalculatedSubTotal
        {
            get
            {
                decimal subTotal = 0.00m;
                foreach (var item in _cartSale.ShoppingCartItems)
                {
                    subTotal += (item.SalePrice * item.Quantity);
                }

                return subTotal;
            }
        }

        public decimal CalculatedSalesTax
        {
            get
            {
                if (_cartSale.ShoppingCartItems.Count() == 0)
                {
                    return 0.00m;
                }

                return (CalculatedSubTotal * 0.06m);
            }
        }

        public decimal CalculatedShippingCost
        {
            get
            {
                if (_cartSale.ShoppingCartItems.Count() == 0)
                {
                    return 0.00m;
                }

                return 9.95m;
            }
        }

        public ShoppingCartSaleModel GetShoppingCart
        {
            get
            {
                return _cartSale;
            }
        }

        public void setShoppingCart(int customerId, DateTime shippingDate, String shipType, decimal subTotal, decimal shippingCost, decimal orderTotal, List<ProductModel> shoppingCartItems)
        {
            _cartSale.CustomerId = customerId;
            _cartSale.ShippingDate = shippingDate;
            _cartSale.ShipType = shipType;
            _cartSale.SubTotal = subTotal;
            _cartSale.ShippingCost = shippingCost;
            _cartSale.OrderTotal = orderTotal;
            _cartSale.ShoppingCartItems = shoppingCartItems;
        }

        public void AddShoppingCartItem(int productId, int quantity, decimal salePrice, string productName)
        {
            if (quantity == 0)
            {
                return;
            }

            var product = _cartSale.ShoppingCartItems.Where(p => p.ProductId == productId);

            if (product.Any())
            {
                int productQuantity = product.First().Quantity;

                if (productQuantity == 6)
                {
                    return;
                }

                if (productQuantity > 0)
                {
                    product.First().Quantity += quantity;
                    productQuantity += quantity;

                    if (productQuantity > 6)
                    {
                        product.First().Quantity = 6;
                    }
                    SetCartTotals();
                    return;
                }
            }

            ProductModel item = new ProductModel
            {
                ProductId = productId,
                Quantity = quantity,
                SalePrice = salePrice,
                Name = productName
            };

            _cartSale.ShoppingCartItems.Add(item);
            SetCartTotals();
        }

        public void IncrementItem(int id)
        {
            var product = _cartSale.ShoppingCartItems.Where(i => i.ProductId == id);
            product.FirstOrDefault().Quantity += 1;
            SetCartTotals();
        }

        public void DecrementItem(int id)
        {
            var product = _cartSale.ShoppingCartItems.Where(i => i.ProductId == id);
            product.FirstOrDefault().Quantity -= 1;
            SetCartTotals();
        }

        public void RemoveItem(int id)
        {
            _cartSale.ShoppingCartItems.RemoveAll(i => i.ProductId == id);
            SetCartTotals();
        }

        private void SetCartTotals()
        {
            _cartSale.SubTotal = CalculatedSubTotal;
            _cartSale.ShippingCost = CalculatedShippingCost;
            _cartSale.SalesTax = Math.Round(CalculatedSalesTax, 2);
            _cartSale.OrderTotal = Math.Round((_cartSale.SubTotal + _cartSale.ShippingCost + _cartSale.SalesTax), 2);
        }

        public void ResetCart()
        {
            _cartSale = new ShoppingCartSaleModel();
        }
    }
}