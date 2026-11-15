using Microsoft.AspNetCore.Mvc;

namespace StudentRegistrationClient_1318.Controllers
{
    public class HomeController : Controller
    {
        // The page is plain HTML; everything after loading runs in the browser.
        public IActionResult Index()
        {
            return View();
        }
    }
}
