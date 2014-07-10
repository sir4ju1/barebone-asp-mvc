using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BareboneFramework.Models;
using Base.Infrastructure;
using Base.Infrastructure.Model;

namespace BareboneFramework.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private BaseDbContext _context;
        public NewsController(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var items = await _context.News.ToListAsync();
            return View(items);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public async Task<ActionResult> Create([Bind(Exclude = "Id")]News model)
        {
            if (ModelState.IsValid)
            {
                model.PublishDate = DateTime.Now;
                _context.Entry(model).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var item = await _context.News.FindAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(News model)
        {
            if (ModelState.IsValid)
            {
                model.PublishDate = DateTime.Now;
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}