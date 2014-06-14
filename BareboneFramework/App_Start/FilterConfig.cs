using System.Web;
using System.Web.Mvc;
using BareboneFramework.Filters;

namespace BareboneFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            var appInfo = DependencyResolver.Current.GetService<ApplicationInfoActionFilter>();
            filters.Add(appInfo, 0);
        }
    }
}
