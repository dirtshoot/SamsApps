using System;
using System.Linq;
using System.Web.Mvc;
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
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var db = new ApplicationDbContext())
            {
                // Create an Admin account
                var admin = LoginsConfig.CreateAdminLogin(db); //uses appsetings AdminName, AdminPasssword, AdminEmail, AdminRole and adds to Admin role
                // Create an User account
                var user = LoginsConfig.CreateLogin(db, "user@server.com", "password", "user@server.com", null); //Adds user to Role if not null
                //user = LoginsConfig.DeleteLogin(db, "zuser@server.com"); //Delete user will return the just deleted user else null
            }
            // Initializes and seeds the database.
            //Database.SetInitializer(new AppDatabaseInitializerAlways());
            // Forces initialization of database on model changes.
            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.Initialize(force: true);
            //}
        }
    }
}