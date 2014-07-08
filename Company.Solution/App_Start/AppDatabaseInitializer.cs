using System;
using System.Data.Entity;
using System.Linq;
using Company.Solution.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Company.Solution
{
    public class AppDatabaseInitializerAlways : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string username;
            string email;
            string password;
            string role;

            AdminAccountWebConfigSettings.GetAdminAccountSettings(out username, out email, out password, out role);

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(role))
            {
                var roleresult = RoleManager.Create(new IdentityRole(role));
            }

            //Create User Admin
            var user = new ApplicationUser { UserName = username, Email = email };
            var adminresult = UserManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, role);
            }
            base.Seed(context);
        }
    }

    public class AppDatabaseInitializerIfModelChanged : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string username;
            string email;
            string password;
            string role;

            AdminAccountWebConfigSettings.GetAdminAccountSettings(out username, out email, out password, out role);

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(role))
            {
                var roleresult = RoleManager.Create(new IdentityRole(role));
            }

            //Create User Admin
            var user = new ApplicationUser { UserName = username, Email = email };
            var adminresult = UserManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, role);
            }
            base.Seed(context);
        }
    }
}