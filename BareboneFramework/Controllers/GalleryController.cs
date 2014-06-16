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
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();
            var items = await _context.GalleryItems.ToListAsync();
            var itemcats = await _context.GalleryItemCategories.ToListAsync();
            var model = new GalleryViewModel();
            model.GalleryItems = Mapper.Map<List<GalleryItem>, List<ImageListViewModel>>(items);
            model.SideMenus = Mapper.Map<List<GalleryItemCategory>, List<ImageListViewModel>>(itemcats);

            return View(model);
        }
        public async Task<ActionResult> Category(int id)
        {
            Mapper.CreateMap<GalleryItem, ImageListViewModel>();
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();
            var items = await _context.GalleryItems.Where(c => c.CategoryId == id).ToListAsync();
            var itemcats = await _context.GalleryItemCategories.ToListAsync();
            var model = new GalleryViewModel();
            model.GalleryItems = Mapper.Map<List<GalleryItem>, List<ImageListViewModel>>(items);
            model.SideMenus = Mapper.Map<List<GalleryItemCategory>, List<ImageListViewModel>>(itemcats);

            return View(model);
        }
        public async Task<ActionResult> Details(int id)
        {
            Mapper.CreateMap<GalleryItem, DetailsViewModel>();
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();
            var itemcats = await _context.GalleryItemCategories.ToListAsync();

            var item = await _context.GalleryItems.FindAsync(id);
            var model = Mapper.Map<GalleryItem, DetailsViewModel>(item);
            model.RelatedImages = await _context.GalleryItems.Where(g => g.CategoryId == model.CategoryId).Select(i => new ImageListViewModel { Id = i.Id, ImagePath = i.ImagePath }).ToListAsync();
            model.SideMenus = Mapper.Map<List<GalleryItemCategory>, List<ImageListViewModel>>(itemcats);


            return View(model);
        }

    }
}