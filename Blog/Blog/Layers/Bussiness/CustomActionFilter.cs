
using System.Web.Mvc;

namespace Blog.Layers.Bussiness
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Oturum süresi dolmuş mu kontrol ediyoruz.
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["Email"] == null)
            {
                // Kullanıcı oturumu yok veya süresi dolmuş, login sayfasına yönlendir.
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Login" }));
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}