using Microsoft.AspNetCore.Mvc;
using StateDemo.Models;

namespace StateDemo.Controllers;

public class HiddenFieldController : Controller
{
    [HttpGet]
    public IActionResult Index() => View(new User { Id = 101, Name = "Abir", Age = 20 });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        ViewData["Message"] = $"Received user ID {user.Id} from the hidden field.";
        return View(user);
    }
}
