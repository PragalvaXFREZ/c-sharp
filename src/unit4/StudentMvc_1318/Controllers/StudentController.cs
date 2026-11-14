using Microsoft.AspNetCore.Mvc;
using StudentMvc_1318.Models;

namespace StudentMvc_1318.Controllers
{
    // Controller: builds the list of students and hands it to the view.
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Pragalva Sapkota", Email = "pragalva@example.com", Address = "Kathmandu" },
                new Student { Id = 2, Name = "Aayush Shrestha", Email = "aayush@example.com", Address = "Lalitpur" },
                new Student { Id = 3, Name = "Sita Gurung", Email = "sita@example.com", Address = "Pokhara" },
                new Student { Id = 4, Name = "Ram Thapa", Email = "ram@example.com", Address = "Bhaktapur" }
            };

            // Passing the list to View() makes it the view's Model.
            return View(students);
        }
    }
}
