using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) 
            {
                return View("UserIndex");
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PreviousGames()
        {
            ViewBag.Message = "Find Previous Games Here!";

            return View();
        }

        public ActionResult NewGame()
        {
            ViewBag.Message = "Here's where you start!";

            return View();
        }


    }
}