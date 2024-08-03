using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;
using MvcProject.Repository;

namespace MvcProject.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository course;
        public CourseController( ICourseRepository course)
        {
            this.course = course;
        }
        public IActionResult ShowCourseById(int id)
        {
            var s = course.GetCourse(id);
            return View("ShowCourseView", s);
        }
        public IActionResult ShowAllCourses()
        {
            List<Course> ListOFCourses = course.GetAllCourses();

            return View("ShowAllCourses", ListOFCourses);
        }

        ApplicationDbContext _context = new ApplicationDbContext();

        #region AddingAction
        public IActionResult NewCourse()
        {
            var Departments = _context.Departments.Select(d => new
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            ViewBag.Departments = Departments;
            return View("NewCourseView", new Course());
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

            return View("NewCourseView", Crs);
        }
        #endregion
        #region edit
        public IActionResult Edit(int id)
        {
            Course ins = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (ins == null)
            {

                return NotFound();
            }

            var Departments = _context.Departments.Select(d => new
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            ViewBag.Departments = Departments;
            return View("EditCourseView", ins);
        }



        [HttpPost]
        public IActionResult SaveEdit(int id, Course newCrs)
        {
            if (newCrs == null || string.IsNullOrEmpty(newCrs.Name))
            {
                ModelState.AddModelError("", "Invalid Course details.");
                return View("EditCourseView", newCrs);
            }

            Course oldCourse = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (oldCourse != null)
            {
                oldCourse.Name = newCrs.Name;
                oldCourse.Degree = newCrs.Degree;
                oldCourse.MinDegree = newCrs.MinDegree;
                oldCourse.DeptId = newCrs.DeptId;

                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Course not found.");
                return View("EditCourseView", newCrs);
            }

            return RedirectToAction("ShowAllCourses");
        }
        #endregion
        #region validation
        public bool CheckDegree(int MinDegree,int Degree)
        {
            return MinDegree <= Degree;
        }
        #endregion


    }
}
