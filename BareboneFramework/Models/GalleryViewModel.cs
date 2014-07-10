using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BareboneFramework.Models
{
    public class GalleryViewModel
    {
        public List<ImageListViewModel> SideMenus { get; set; }
        public PagedList.IPagedList<ImageListViewModel> GalleryItems { get; set; }
    }
}