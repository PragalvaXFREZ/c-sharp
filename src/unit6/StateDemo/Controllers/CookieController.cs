using Microsoft.AspNetCore.Mvc;

namespace StateDemo.Controllers;

public class CookieController : Controller
{
    private const string UserNameCookie = "UserName";

    [HttpGet]
    public IActionResult Index()
    {
        ViewData["UserName"] = Request.Cookies[UserNameCookie];
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            ModelState.AddModelError(nameof(userName), "Enter a name.");
            return View();
        }

        Response.Cookies.Append(UserNameCookie, userName.Trim(), new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddMinutes(30),
            HttpOnly = true,
            IsEssential = true,
            SameSite = SameSiteMode.Lax
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove()
    {
        Response.Cookies.Delete(UserNameCookie);
        return RedirectToAction(nameof(Index));
    }
}
