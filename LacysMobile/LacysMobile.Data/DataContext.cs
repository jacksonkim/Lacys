using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Configuration;
using LacysMobile.Data.Configuration;
using LacysMobile.Models;

namespace LacysMobile.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }

        static DataContext()
        {
            Database.SetInitializer(new CustomDbInit());//Comment out this line on deployment to the web
            //Database.SetInitializer<DbContext>(null); // use this line on deployment to the web
        }

        public DataContext() : base(nameOrConnectionString: DataContext.ConnectionStringName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new MembershipConfig());
            modelBuilder.Configurations.Add(new OAuthMembershipConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new ProductReviewConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new OrderItemsConfig());
            modelBuilder.Configurations.Add(new FeedbackConfig());
            modelBuilder.Configurations.Add(new SaleConfig());
            modelBuilder.Configurations.Add(new InventoryConfig());
            modelBuilder.Configurations.Add(new CreditCardConfig());
            base.OnModelCreating(modelBuilder);//Comment out this line on deployment to the web
        }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
