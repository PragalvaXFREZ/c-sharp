using Microsoft.AspNetCore.Mvc;

namespace StateDemo.Controllers;

public class SessionController : Controller
{
    private const string UserNameKey = "UserName";
    private const string VisitCountKey = "VisitCount";

    [HttpGet]
    public IActionResult Index()
    {
        int visitCount = HttpContext.Session.GetInt32(VisitCountKey) ?? 0;
        HttpContext.Session.SetInt32(VisitCountKey, ++visitCount);

        ViewData["UserName"] = HttpContext.Session.GetString(UserNameKey);
        ViewData["VisitCount"] = visitCount;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Save(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            TempData["Message"] = "Enter a name before saving the session.";
            return RedirectToAction(nameof(Index));
        }

        HttpContext.Session.SetString(UserNameKey, userName.Trim());
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Index));
    }
}
