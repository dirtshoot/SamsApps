using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Solution.Controllers
{
    public class PluginsController : Controller
    {
        // GET: Plugins
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BootstrapCarousel()
        {
            return View();
        }
        public ActionResult BootstrapLightBox()
        {
            return View();
        }
        public ActionResult BootstrapLightBoxDark()
        {
            return View();
        }
       public ActionResult GlyphIcons()
        {
            return View();
        }
    }
}