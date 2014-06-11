using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BareboneFramework.Models;

namespace BareboneFramework.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var model = new DetailsViewModel
            {
                Name = "Some Name",
                ItemInfo = "<div><h4>Some Information</h4></div>",
                Description = "<div><h4>Some Description</h4></div>",
                ImageLocation = "http://lorempixel.com/400/300/sports/2/"
            };
            return View(model);
        }
    }
}