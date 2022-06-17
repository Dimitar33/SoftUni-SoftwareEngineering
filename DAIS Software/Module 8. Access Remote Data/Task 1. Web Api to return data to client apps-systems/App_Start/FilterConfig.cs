using System.Web;
using System.Web.Mvc;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
