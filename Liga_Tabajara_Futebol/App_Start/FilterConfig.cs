using System.Web;
using System.Web.Mvc;

namespace Liga_Tabajara_Futebol
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
