using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebMatrix.WebData;
using System.Web.Mvc;
using LacysMobile.Web.Models;
using System.Threading;
using System.Web.Security;

namespace LacysMobile.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }
                    if (!WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection(
                            Config.ConnectionStringName,
                            Config.UsersTableName,
                            Config.UsersPrimaryKeyColumnName,
                            Config.UsersUserNameColumnName,
                            autoCreateTables: true);
                        #region "Seed Users and Roles"
                        if (!Roles.RoleExists("Administrator"))
                            Roles.CreateRole("Administrator");

                        if (!Roles.RoleExists("Employee"))
                            Roles.CreateRole("Employee");

                        if (!WebSecurity.UserExists("Employee1"))
                            WebSecurity.CreateUserAndAccount(
                                "Employee1",
                                "password",
                                new
                                {
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now,
                                    UserName = "Employee1"
                                });

                        if (!WebSecurity.UserExists("Employee2"))
                            WebSecurity.CreateUserAndAccount(
                                "Employee2",
                                "password",
                                new
                                {
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now,
                                    UserName = "Employee1"
                                });

                        if (!WebSecurity.UserExists("Admin"))
                            WebSecurity.CreateUserAndAccount(
                                "Admin",
                                "password",
                                new
                                {
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now,
                                    UserName = "Admin"
                                });

                        if (!Roles.GetRolesForUser("Admin").Contains("Administrator"))
                            Roles.AddUsersToRoles(new[] { "Admin" }, new[] { "Administrator" });

                        if (!Roles.GetRolesForUser("Employee1").Contains("Employee"))
                            Roles.AddUsersToRoles(new[] { "Employee1" }, new[] { "Employee" });

                        if (!Roles.GetRolesForUser("Employee2").Contains("Employee"))
                            Roles.AddUsersToRoles(new[] { "Employee2" }, new[] { "Employee" });
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}