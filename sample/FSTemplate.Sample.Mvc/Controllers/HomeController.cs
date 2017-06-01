using FSTemplate.Sample.Mvc.Models;
using System.Web.Mvc;

namespace FSTemplate.Sample.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new IndexModel
            {
                Name = "Hello World",
                Values = new[] { 1, 2, 3, 4, 5 }
            };
            return View(model);
        }
    }
}