using BPS.HiltonDirect.WebApp.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPS.HiltonDirect.WebApp.Controllers
{
    [AuthorizeApi]
    public class BaseController : Controller
    {
    }
}