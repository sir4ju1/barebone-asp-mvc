using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Base.Infrastructure;

namespace BareboneFramework.Controllers
{
    public class NewsController : Controller
    {
        private BaseDbContext _context;

        public NewsController(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _context.News.ToListAsync();
            return View(model);
        }
        public async Task<ActionResult> Details(int id)
        {
            var model = await _context.News.FindAsync(id);
            return View(model);
        }
    }
}