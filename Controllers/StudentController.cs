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
                Courses = student.crsResults.Select(cr => new CourseDetail
                {
                    CourseName = cr.Course.Name,
                    CourseDegree = cr.Degree,
                    MaxGrade = cr.Course.Degree,
                    MinGrade = cr.Course.MinDegree
                }).ToList()
            };
            //string Color;
            //if(student.Grade>= student.crsResults)
            //{
            //    Color = "Green";
            //}
            //else
            //{
            //    Color = "red";
            //}
            //ViewData["clr"] = Color;
            ViewData["StudentDetails"] = studentViewModel;

            return View("DetailsView");
        }

        public IActionResult ShowAll()
        {
            var students = _context.Students.ToList();
            ViewData["StudentList"] = students;

            return View("ShowAllView");
        }
    }
}
