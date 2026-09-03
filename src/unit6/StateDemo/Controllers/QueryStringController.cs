using Microsoft.AspNetCore.Mvc;
using StateDemo.Models;

namespace StateDemo.Controllers;

public class QueryStringController : Controller
{
    [HttpGet]
    public IActionResult Index(User? user)
    {
        bool hasQuery = Request.Query.ContainsKey(nameof(StateDemo.Models.User.Name));
        ViewData["HasQuery"] = hasQuery;
        return View(hasQuery ? user : null);
    }
}
