using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using AutoMapper;
using BareboneFramework.Models;
using Base.Infrastructure;
using Base.Infrastructure.Model;
using PagedList;

namespace BareboneFramework.Controllers
{
    public class GalleryController : Controller
    {
        private BaseDbContext _context;
        private int _pageItems;

        public GalleryController(BaseDbContext context)
        {
            _context = context;
            _pageItems = Convert.ToInt16(WebConfigurationManager.AppSettings.Get("PageItems"));
        }
        // GET: Gallery
        public async Task<ActionResult> Index(int? page)
        {
            int pageNumber = (page ?? 1);
            Mapper.CreateMap<GalleryItem, ImageListViewModel>();
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();
            var items = _context.GalleryItems.OrderBy(o => o.Name).ToPagedList(pageNumber, _pageItems);
            var itemcats = await _context.GalleryItemCategories.ToListAsync();
            var model = new GalleryViewModel();
            model.GalleryItems = items.ToMappedPagedList<GalleryItem, ImageListViewModel>();
            model.SideMenus = Mapper.Map<List<GalleryItemCategory>, List<ImageListViewModel>>(itemcats);

            return View(model);
        }
        public async Task<ActionResult> Category(int id, int? page)
        {
            int pageNumber = (page ?? 1);
            Mapper.CreateMap<GalleryItem, ImageListViewModel>();
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();
            var items = _context.GalleryItems.Where(c => c.CategoryId == id).OrderBy(o => o.Name).ToPagedList(pageNumber, _pageItems);
            var itemcats = await _context.GalleryItemCategories.ToListAsync();
            var model = new GalleryViewModel();
            model.GalleryItems = items.ToMappedPagedList<GalleryItem, ImageListViewModel>();
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
            model.RelatedImages = await _context.GalleryItems.Where(g => g.CategoryId == model.CategoryId).Select(i => new ImageListViewModel { Id = i.Id, Name = i.Name, ImagePath = i.ImagePath }).ToListAsync();
            model.SideMenus = Mapper.Map<List<GalleryItemCategory>, List<ImageListViewModel>>(itemcats);


            return View(model);
        }



    }

    public static class ExtensionMethods
    {
        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        {
            IEnumerable<TDestination> sourceList = Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
            return pagedResult;

        }
    }
}