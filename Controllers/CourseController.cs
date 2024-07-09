using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class CourseController : Controller
    {
        Course course = new Course();
        public IActionResult GetCourseById(int id)
        {
            var s = course.GetCourse(id);
            return View("ShowCourseView",s);
        }
    }
}
