using System;
using System.Linq;
using System.Web.Configuration;

namespace Company.Solution
{
    public static class AdminAccountWebConfigSettings
    {
        public static void GetAdminAccountSettings(out string username, out string email, out string password, out string role)
        {
            username = WebConfigurationManager.AppSettings["AdminName"].ToString();
            email = WebConfigurationManager.AppSettings["AdminEmail"].ToString();
            password = WebConfigurationManager.AppSettings["AdminPasssword"].ToString();
            role = WebConfigurationManager.AppSettings["AdminRole"].ToString();
        }
    }
}