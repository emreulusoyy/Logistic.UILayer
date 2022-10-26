using System.Web;
using System.Web.Mvc;

namespace Logistic.UILayer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
