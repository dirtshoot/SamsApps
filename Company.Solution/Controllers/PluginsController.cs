using System;
using System.Linq;
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

        public ActionResult BootstrapCarouselBlock()
        {
            return View();
        }

        public ActionResult BootstrapCarouselSingle()
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