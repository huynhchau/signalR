using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPS.HiltonDirect.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = Model.Resource.hilton_direct_form_title;
            return View();
        }
    }
}