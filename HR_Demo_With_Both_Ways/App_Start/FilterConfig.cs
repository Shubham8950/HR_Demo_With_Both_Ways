using System.Web;
using System.Web.Mvc;

namespace HR_Demo_With_Both_Ways
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
