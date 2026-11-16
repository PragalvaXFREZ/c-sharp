using Microsoft.AspNetCore.Mvc;
using SessionStateDemo_1318.Models;

namespace SessionStateDemo_1318.Controllers
{
    public class StudentController : Controller
    {
        // Page 1: store the user's name and age in Session State.
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Pragalva Sapkota");
            HttpContext.Session.SetInt32("Age", 21);
            return View();
        }

        // Page 2: a separate request that reads the values back from the session.
        public IActionResult Details()
        {
            User user = new User
            {
                Id = 1318,
                Name = HttpContext.Session.GetString("Name"),
                Age = HttpContext.Session.GetInt32("Age") ?? 0
            };
            return View(user);
        }
    }
}
