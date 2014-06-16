using System.Collections.Generic;
using System.Web.Mvc;

namespace BareboneFramework.Models
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [AllowHtml]
        public string Summary { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public List<ImageListViewModel> RelatedImages { get; set; }
        public List<ImageListViewModel> SideMenus { get; set; }
        public List<SelectListItem> ListItems { get; set; } 

    }
}