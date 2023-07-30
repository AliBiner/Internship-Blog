
using System.Web.Mvc;
using Blog.Layers.Bussiness.Services.EntryService;


namespace Blog.Controllers
{
    
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            
            if (Session["Role"] == null)
            {
                return View();
            }
            else
            {
                
                ViewBag.Role = Session["Role"].ToString();
                return View();
            }
            
        }

       


    }
}