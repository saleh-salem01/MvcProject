using MvcProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MvcProject.ViewModel;

namespace MvcProject.Controllers
{
    public class StudentController : Controller
    {
        Student studentsData = new Student();
        ApplicationDbContext _context=new ApplicationDbContext();
        public IActionResult ShowDetails(int id)
        {
            var studentCourses = from student in _context.Students
                                 join crsResult in _context.CrsResults on student.ID equals crsResult.StudId
                                 join course in _context.Courses on crsResult.CrsId equals course.Id
                                 select new StudentViewModel
                                 {
                                     StudentName = student.Name,
                                     CourseName = course.Name,
                                     CourseDegree = crsResult.Degree,
                                     MaxGrade = course.Degree,
                                     MinGrade = course.MinDegree
                                 };

            var Student = studentsData.GetStudent(id);
            return View("DetailsView", studentCourses);
        }
        public IActionResult ShowAll() 
        {
            var StudentList = studentsData.GetStudents();
            return View("ShowAllView", StudentList);
        }
    }
}
