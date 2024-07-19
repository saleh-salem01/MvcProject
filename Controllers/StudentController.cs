using MvcProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject.ViewModel;
using System.Linq;
using System.Collections.Generic;

namespace MvcProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ShowDetails(int id)
        {
            var student = _context.Students
                .Include(s => s.crsResults)
                .ThenInclude(cr => cr.Course)
                .FirstOrDefault(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            var studentViewModel = new StudentCourseViewModel
            {
                StudentName = student.Name,
                StudentImage = student.Image ?? "defaultImage.jpg", // تأكد من أن الصورة ليست null
                Courses = student.crsResults?.Select(cr => new CourseDetail
                {
                    CourseName = cr.Course?.Name ?? "Unknown Course", // تأكد من أن اسم الكورس ليس null
                    CourseDegree = cr.Degree,
                    MaxGrade = cr.Course?.Degree ?? 0,
                    MinGrade = cr.Course?.MinDegree ?? 0
                }).ToList() ?? new List<CourseDetail>() // تأكد من أن قائمة الكورسات ليست null
            };

            ViewBag.StudentDetails = studentViewModel;
            return View("DetailsView",student);
        }


        public IActionResult ShowAll()
        {
            var students = _context.Students.ToList();
            ViewData["StudentList"] = students;

            return View("ShowAllView");
        }

        public IActionResult NewStudent()
        {
            return View("NewStudent");
        }
        public IActionResult SaveChanges(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return View("NewStudent");
        }
    }
}
