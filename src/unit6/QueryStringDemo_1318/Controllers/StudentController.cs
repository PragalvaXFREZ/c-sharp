using Microsoft.AspNetCore.Mvc;

namespace QueryStringDemo_1318.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Model binding fills id and name from the query string:
        // /Student/Display?id=1318&name=Pragalva+Sapkota
        public IActionResult Display(int id, string name)
        {
            ViewBag.StudentId = id;
            ViewBag.StudentName = name;
            return View();
        }
    }
}
