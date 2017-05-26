using FSTemplate.Sample.Models;
using System.Web.Mvc;

namespace FSTemplate.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new IndexModel
            {
                Name = "Hello World",
                Values = new[] { 0, 1, 2, 3, 4 }
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}