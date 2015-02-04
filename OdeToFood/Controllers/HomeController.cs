
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Razor.Text;
using System.Web.UI;
using OdeToFood.Models;
using PagedList;


namespace OdeToFood.Controllers
{

    public class HomeController : Controller
    {
        private IOdeToFoodDb _db;

        public HomeController()
        {
            _db = new OdeToFoodDb();
        }

        public HomeController(IOdeToFoodDb db)
        {
            _db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Query<Restaurant>()
                    .Where(r => r.Name.StartsWith(term))
                    .Take(10)
                    .Select(r => new
                    {
                        label = r.Name
                    });
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [OutputCache(CacheProfile = "Long", VaryByHeader = "X-Requested-With", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {

            var model =
                _db.Query<Restaurant>()
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    //.Take(10)
                    .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                    .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.Reviews.Count()
                    }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

 
        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Scott";
            model.Location = "Singapore";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
