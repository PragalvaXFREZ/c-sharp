using Microsoft.AspNetCore.Mvc;

namespace StateDemo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    [Route("Home/Error")]
    public IActionResult Error() => Problem("An unexpected error occurred.");
}
