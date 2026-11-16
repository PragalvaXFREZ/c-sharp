using Microsoft.AspNetCore.Mvc;

namespace CookieDemo_1318.Controllers
{
    public class StudentController : Controller
    {
        // Read: get the cookie the browser sent with this request.
        public IActionResult Index()
        {
            string? userName = Request.Cookies["UserName"];
            return View("Index", userName);
        }

        // Create / Update: appending a cookie with the same key overwrites it.
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            string userName = form["userName"].ToString();

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("UserName", userName, option);

            return RedirectToAction(nameof(Index));
        }

        // Delete: tell the browser to remove the cookie.
        public IActionResult RemoveCookie()
        {
            Response.Cookies.Delete("UserName");
            return RedirectToAction(nameof(Index));
        }
    }
}
