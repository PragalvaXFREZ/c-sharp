using Microsoft.AspNetCore.Mvc;
using StudentValidation_1318.Models;

namespace StudentValidation_1318.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Student student)
        {
            // The same attributes are checked again on the server,
            // so the rules hold even when JavaScript is turned off.
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            return View("Success", student);
        }
    }
}
