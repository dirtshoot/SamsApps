using System;
using System.Linq;
using System.Web.Configuration;

namespace Company.Solution
{
    public static class ThemeWebConfigSettings
    {
        public static string GetThemeName()
        {
            return WebConfigurationManager.AppSettings["ThemeName"].ToString();
        }
    }
}