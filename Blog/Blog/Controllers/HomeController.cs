using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.Bussiness;
using Blog.Models.Context;

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