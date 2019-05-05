using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.ITI.UI.MVC.Day3.Lab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
