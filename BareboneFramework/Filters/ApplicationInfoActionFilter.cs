using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using BareboneFramework.Models;
using Base.Infrastructure;
using Microsoft.Practices.Unity;

namespace BareboneFramework.Filters
{
    public class ApplicationInfoActionFilter : ActionFilterAttribute
    {
        [Dependency]
        public BaseDbContext Context { private get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (GlobalData.AppInfo == null)
            {
                var info = Context.ApplicationInfo.FirstOrDefault();
                GlobalData.AppInfo = info;
            }
        }
    }
}