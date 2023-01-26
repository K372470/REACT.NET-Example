using Microsoft.AspNetCore.Mvc;

namespace DriveHack.Site.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult MainPage()
        {
            return View();
        }
        [Route("/details")]
        public ActionResult Details()
        {
            return View();
        }
    }
}
