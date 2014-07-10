using Base.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BareboneFramework.Controllers
{
    public class HomeController : Controller
    {
        private BaseDbContext _context;
        public HomeController(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _context.News.OrderByDescending(o => o.PublishDate).Take(5).ToListAsync();
            return View(model);
        }
    }
}
