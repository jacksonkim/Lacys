using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LacysMobile.Models;
using LacysMobile.Data.Interfaces;

namespace LacysMobile.Data
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _context = new DataContext();

        private IRepository<User> _users = null;

        private UserRepository _usersAndEntities = null;

        private IRepository<Product> _products = null;
        private IRepository<ProductReview> _reviews = null;
        private IRepository<Order> _order = null;
        private IRepository<OrderItem> _orderItem = null;
        private IRepository<Feedback> _feedback = null;
        private IRepository<Sale> _sales = null;
        private IRepository<Inventory> _inventory = null;
        private IRepository<CreditCard> _creditCard = null;

        public IRepository<User> Users
        {

            get
            {

                if (this._users == null)
                {

                    this._users = new BaseRepository<User>(this._context);

                }



                return this._users;

            }

        }

        public UserRepository UsersEntities
        {

            get
            {

                if (this._usersAndEntities == null)
                {

                    this._usersAndEntities = new UserRepository(this._context);

                }



                return this._usersAndEntities;

            }

        }

        public IRepository<Product> Products
        {

            get
            {

                if (this._products == null)
                {

                    this._products = new BaseRepository<Product>(this._context);

                }



                return this._products;

            }

        }

        public IRepository<ProductReview> ProductReviews
        {

            get
            {

                if (this._reviews == null)
                {

                    this._reviews = new BaseRepository<ProductReview>(this._context);

                }



                return this._reviews;

            }

        }

        public IRepository<Sale> Sales
        {

            get
            {

                if (this._sales == null)
                {

                    this._sales = new BaseRepository<Sale>(this._context);

                }



                return this._sales;

            }

        }

        public IRepository<Inventory> Inventory
        {

            get
            {

                if (this._inventory == null)
                {

                    this._inventory = new BaseRepository<Inventory>(this._context);

                }



                return this._inventory;

            }

        }

        public IRepository<Order> Orders
        {

            get
            {

                if (this._order == null)
                {

                    this._order = new BaseRepository<Order>(this._context);

                }



                return this._order;

            }

        }

        public IRepository<OrderItem> OrderItem
        {

            get
            {

                if (this._orderItem == null)
                {

                    this._orderItem = new BaseRepository<OrderItem>(this._context);

                }



                return this._orderItem;

            }

        }

        public IRepository<Feedback> Feedback
        {

            get
            {

                if (this._feedback == null)
                {

                    this._feedback = new BaseRepository<Feedback>(this._context);

                }



                return this._feedback;

            }

        }

        public IRepository<CreditCard> CreditCard
        {

            get
            {

                if (this._creditCard == null)
                {

                    this._creditCard = new BaseRepository<CreditCard>(this._context);

                }



                return this._creditCard;

            }

        }

        public void SaveChanges()
        {

            this._context.SaveChanges();

        }

        public void Dispose()
        {

            if (this._context != null)
            {

                this._context.Dispose();

            }

        }
    }
}
