using System.Web;
using System.Web.Mvc;

namespace PatientManagementSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); //Apply Authorization on All Controllers/Pages
            filters.Add(new RequireHttpsAttribute());//Require secure Https Chanel
        }
    }
}
