using System.Web;
using System.Web.Mvc;

namespace Awapi.DealerAndVehicles.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
