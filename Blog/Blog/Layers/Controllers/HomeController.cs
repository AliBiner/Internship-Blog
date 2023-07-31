
using System.Web.Mvc;
using Blog.Layers.Bussiness;
using Blog.Layers.Bussiness.Services.EntryService;


namespace Blog.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IEntryService _entryService;

        public HomeController(IEntryService entryService)
        {
            _entryService = entryService;
        }


        public ActionResult Index()
        {
            var model = _entryService.GetTenEntry();
            
            if (Session["Role"]==null)
            {
                return View(model);
            }
            else
            {
                ViewBag.Role = Session["Role"].ToString();
                return View(model);
            }
            
        }

       


    }
}