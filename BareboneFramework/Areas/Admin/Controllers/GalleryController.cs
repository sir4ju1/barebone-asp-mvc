using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.Infrastructure;

namespace BareboneFramework.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        private BaseDbContext _context;
        public GalleryController(BaseDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var model = _context.GalleryItems.ToList();
            return View(model);
        }
    }
}