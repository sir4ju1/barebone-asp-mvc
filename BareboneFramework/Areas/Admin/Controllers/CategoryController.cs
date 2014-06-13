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
    public class CategoryController : Controller
    {
        private BaseDbContext _context;
        public CategoryController(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();
            var items = await _context.GalleryItemCategories.ToListAsync();
            var model = Mapper.Map<List<GalleryItemCategory>, List<ImageListViewModel>>(items);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")]DetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<DetailsViewModel, GalleryItemCategory>();
                var item = Mapper.Map<DetailsViewModel, GalleryItemCategory>(model);
                _context.Entry(item).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var item = await _context.GalleryItemCategories.FindAsync(id);

            Mapper.CreateMap<GalleryItemCategory, DetailsViewModel>();
            var model = Mapper.Map<GalleryItemCategory, DetailsViewModel>(item);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}