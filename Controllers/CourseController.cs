using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class CourseController : Controller
    {
        Course course = new Course();
        public IActionResult ShowCourseById(int id)
        {
            var s = course.GetCourse(id);
            return View("ShowCourseView",s);
        }
        public IActionResult ShowAllCourses(int id) {
            List<Course> ListOFCourses = course.GetAllCourses();

            return View("ShowAllCourses",ListOFCourses);
        }
        
    }
}
