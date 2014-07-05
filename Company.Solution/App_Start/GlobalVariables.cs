using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Company.Solution
{
    static public class GlobalVariables
    {
        public static string HeaderText
        {
            get
            {
                return WebConfigurationManager.AppSettings["HeaderText"].ToString();
            }
        }

        public static string ApplicationTitle 
        {
            get
            {
                return WebConfigurationManager.AppSettings["ApplicationTitle"].ToString();
            }
        }

        public static string CompanyName
        {
            get
            {
                return WebConfigurationManager.AppSettings["CompanyName"].ToString();
            }
        }
        public static string CompanyContactName
        {
            get
            {
                return WebConfigurationManager.AppSettings["CompanyContactName"].ToString();
            }
        }
        public static string CompanyContactEmail
        {
            get
            {
                return WebConfigurationManager.AppSettings["CompanyContactEmail"].ToString();
            }
        }
        public static string CompanyAddress
        {
            get
            {
                return WebConfigurationManager.AppSettings["CompanyAddress"].ToString();
            }
        }
        public static string CompanyCSZ
        {
            get
            {
                return WebConfigurationManager.AppSettings["CompanyCSZ"].ToString();
            }
        }
        public static string CompanyPhone
        {
            get
            {
                return WebConfigurationManager.AppSettings["CompanyPhone"].ToString();
            }
        }
        public static string SiteAuthorName
        {
            get
            {
                return WebConfigurationManager.AppSettings["SiteAuthorName"].ToString();
            }
        }
        public static string SiteAuthorEmail
        {
            get
            {
                return WebConfigurationManager.AppSettings["SiteAuthorEmail"].ToString();
            }
        }

    }
}