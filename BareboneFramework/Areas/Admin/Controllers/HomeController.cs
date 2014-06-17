using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BareboneFramework.Filters;
using BareboneFramework.Models;
using Base.Infrastructure;
using Base.Infrastructure.Model;

namespace BareboneFramework.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private BaseDbContext _context;
        public HomeController(BaseDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _context.ApplicationInfo.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ApplicationInfo model, HttpPostedFileBase logofile, HttpPostedFileBase headerbg)
        {
            if (ModelState.IsValid)
            {
                model.LogoPath = SaveImageFile(logofile) ?? model.LogoPath;
                model.HeaderBackground = SaveImageFile(headerbg) ?? model.HeaderBackground;

                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                GlobalData.AppInfo = model;
            }             
            

            return View(model);
        }

        private string SaveImageFile(HttpPostedFileBase file)
        {
            string filePath = null;
            if (file != null && file.ContentLength > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                filePath = Path.Combine(Server.MapPath("~/Public/Images"), filename);
                file.SaveAs(filePath);
                filePath = string.Format("~/Public/Images/{0}", filename);
            }
            return filePath;
        }
    }
}