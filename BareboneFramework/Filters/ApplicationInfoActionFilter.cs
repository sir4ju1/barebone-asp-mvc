using System.Web.Mvc;

namespace BareboneFramework.Filters
{
    public class ApplicationInfoActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

            filterContext.Controller.ViewBag.Title = "Home Page";
            filterContext.Controller.ViewBag.IsImage = true;
            filterContext.Controller.ViewBag.LogoSrc = @"Content/Images/Logo.png";
            filterContext.Controller.ViewBag.Name = "Company Name";
            filterContext.Controller.ViewBag.Background = @"Content/Images/Header-bg.png";

        }
    }
}