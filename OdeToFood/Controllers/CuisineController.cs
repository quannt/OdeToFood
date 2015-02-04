using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OdeToFood.Filters;

namespace OdeToFood.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
    
        public ActionResult Search(string name)
        {
            throw new Exception("Oh no..!!");
            var message = Server.HtmlEncode(name);
            return Json(new {Message = message, Name = "Scott"}, JsonRequestBehavior.AllowGet);
        }


    }
}
