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
using Microsoft.Ajax.Utilities;

namespace BareboneFramework.Controllers
{
    public class GalleryController : Controller
    {
        private BaseDbContext _context;

        public GalleryController(BaseDbContext context)
        {
            _context = context;
        }
        // GET: Gallery
        public async Task<ActionResult> Index()
        {
            Mapper.CreateMap<GalleryItem, ImageListViewModel>();
            var items = await _context.GalleryItems.ToListAsync();
            var model = Mapper.Map<List<GalleryItem>, List<ImageListViewModel>>(items);
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            Mapper.CreateMap<GalleryItem, DetailsViewModel>();
            var item = await _context.GalleryItems.FindAsync(id);
            var model = Mapper.Map<GalleryItem, DetailsViewModel>(item);
            model.RelatedImages = await _context.GalleryItems.Where(g => g.CategoryId == model.CategoryId).Select(i => new ImageListViewModel { Id = i.Id, ImagePath = i.ImagePath}).ToListAsync();

            return View(model);
        }

    }
}