using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BareboneFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.IsImage = true;
            ViewBag.LogoSrc = @"Content/Images/Logo.png";
            ViewBag.Name = "Company Name";
            ViewBag.Background = @"Content/Images/Header-bg.png";

            return View();
        }
    }
}
