using Microsoft.AspNetCore.Mvc;
using HiddenFieldDemo_1318.Models;

namespace HiddenFieldDemo_1318.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Edit()
        {
            Student student = new Student { Id = 1318, Name = "Pragalva Sapkota", Age = 21 };
            return View(student);
        }

        // The Id is not shown on the form; it comes back from the hidden field.
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            // ViewBag: data for this one response only.
            ViewBag.Id = student.Id;
            ViewBag.Name = student.Name;
            ViewBag.Age = student.Age;

            // TempData: kept until it is read (it would also survive a redirect).
            TempData["Message"] = $"Student {student.Id} was updated.";

            return View(student);
        }
    }
}
