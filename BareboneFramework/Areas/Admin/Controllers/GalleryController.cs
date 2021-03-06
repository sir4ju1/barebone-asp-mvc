﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
    public class GalleryController : Controller
    {
        private BaseDbContext _context;
        public GalleryController(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            Mapper.CreateMap<GalleryItem, ImageListViewModel>();
            var items = await _context.GalleryItems.ToListAsync();
            var model = Mapper.Map<List<GalleryItem>, List<ImageListViewModel>>(items);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();

            var model = new DetailsViewModel();
            model.ListItems = await _context.GalleryItemCategories.Select(c =>
                  new SelectListItem
                  {
                      Text = c.Name,
                      Value = c.Id.ToString()
                  }).ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")]DetailsViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var filename = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Public/Images"), filename);
                    image.SaveAs(path);
                    model.ImagePath = string.Format("~/Public/Images/{0}", filename);
                }
                Mapper.CreateMap<DetailsViewModel, GalleryItem>();
                var item = Mapper.Map<DetailsViewModel, GalleryItem>(model);
                _context.Entry(item).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Update(int id)
        {
            Mapper.CreateMap<GalleryItemCategory, ImageListViewModel>();
            Mapper.CreateMap<GalleryItem, DetailsViewModel>();

            //var model = new DetailsViewModel();
            
            var gallery = await _context.GalleryItems.FindAsync(id);
            var model = Mapper.Map<GalleryItem, DetailsViewModel>(gallery);
            model.ListItems = await _context.GalleryItemCategories.Select(c =>
                  new SelectListItem
                  {
                      Text = c.Name,
                      Value = c.Id.ToString()
                  }).ToListAsync();
            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Update(DetailsViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var filename = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Public/Images"), filename);
                    image.SaveAs(path);
                    model.ImagePath = string.Format("~/Public/Images/{0}", filename);
                }
                Mapper.CreateMap<DetailsViewModel, GalleryItem>();
                var item = Mapper.Map<DetailsViewModel, GalleryItem>(model);
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}