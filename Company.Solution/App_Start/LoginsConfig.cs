using System;
using System.Linq;
using Company.Solution.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Company.Solution
{
    public class LoginsConfig
    {
        public static ApplicationUser CreateAdminLogin(ApplicationDbContext db)
        {
            try
            {
                string username;
                string email;
                string password;
                string role;

                AdminAccountWebConfigSettings.GetAdminAccountSettings(out username, out email, out password, out role);
                return CreateLogin(db, username, password, email, role);
            }
            catch
            {
                return null;
            }
        }

        public static ApplicationUser CreateLogin(ApplicationDbContext db, string username, string password, string email, string rolename)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var user = userManager.FindByName(username);
                if (user == null)
                {
                    user = CreateUserAccount(db, userManager, username, password, email, rolename);
                }
                return user;
            }
            catch
            {
                return null;
            }
        }

        public static ApplicationUser DeleteLogin(ApplicationDbContext db, string username)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var user = userManager.FindByName(username);
                if (user != null)
                {
                    userManager.Delete(user);
                }
                return user;
            }
            catch
            {
                return null;
            }
        }

        private static ApplicationUser CreateUserAccount(ApplicationDbContext db, UserManager<ApplicationUser> userManager, string username, string password, string email, string rolename)
        {
            try
            {
                //Create Admin
                var user = new ApplicationUser() { UserName = username, Email = email, EmailConfirmed = true };
                var umresult = userManager.Create(user, password);

                //Add User Admin to UserRole Admin
                if (umresult.Succeeded)
                {
                    // Add user admin to UserRole Admin if not already added
                    if (rolename != null)
                    {
                        CreateRole(db, rolename);
                        var rolesForUser = userManager.GetRoles(user.Id);

                        if (!rolesForUser.Contains(rolename))
                        {
                            var result = userManager.AddToRole(user.Id, rolename);
                        }
                    }
                }
                return user;
            }
            catch
            {
                return null;
            }
        }

        private static IdentityRole CreateRole(ApplicationDbContext db, string rolename)
        {
            try
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                //Create UserRole Admin if it does not exist
                var role = roleManager.FindByName(rolename);
                if (role == null)
                {
                    role = new IdentityRole { Name = rolename };
                    var roleresult = roleManager.Create(role);
                }
                return role;
            }
            catch
            {
                return null;
            }
        }
    }
}