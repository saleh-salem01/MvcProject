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
        public IActionResult ShowAllCourses() {
            List<Course> ListOFCourses = course.GetAllCourses();

            return View("ShowAllCourses",ListOFCourses);
        }

        ApplicationDbContext _context = new ApplicationDbContext();

        #region AddingAction
        public IActionResult NewCourse()
        {
            var Departments = _context.Departments.Select(d=> new
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            ViewBag.Departments = Departments;
            return View("NewCourseView",new Course());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult SaveCourseChanges(Course Crs)
        {
            if (Crs.Name != null)
            {
                _context.Courses.Add(Crs);
                _context.SaveChanges();
                
                return RedirectToAction("ShowAllCourses");
            }

            return View("NewCourseView",Crs);
        }
        #endregion


    }
}
