using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Company.Solution.Models;

namespace Company.Solution
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //2 Ways to init a ASP.Net Ientity database

            //Sam's Way: Always Ensure these Logins will exist on database creation or if deleted from database
            using (var db = new ApplicationDbContext())
            {
                // Create an Admin account
                var admin = LoginsConfig.CreateAdminLogin(db); //uses appsetings AdminName, AdminPasssword, AdminEmail, AdminRole and adds to Admin role
                // Create an User account
                //var user = LoginsConfig.CreateLogin(db, "user@server.com", "password", "user@server.com", null); //Adds user to Role if not null
                //user = LoginsConfig.DeleteLogin(db, "zuser@server.com"); //Delete user will return the just deleted user else null

            }
            
            //Using SetInitializers
            //Initializes and seeds the database.
            
            //Database.SetInitializer(new AppDatabaseInitializerAlways());
            //  OR
            //Database.SetInitializer(new AppDatabaseInitializerIfModelChanged());
            // Forces initialization of database on model changes.
            
            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.Initialize(force: true);
            //}
        }
    }
}
