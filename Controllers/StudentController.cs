using MvcProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MvcProject.Controllers
{
    public class StudentController : Controller
    {
        StudentSampleData studentsData = new StudentSampleData();

        public IActionResult ShowDetails(int id)
        {
            var Student = studentsData.GetStudent(id);
            return View("DetailsView", Student);
        }
        public IActionResult ShowAll() 
        {
            var StudentList = studentsData.GetStudents();
            return View("ShowAllView", StudentList);
        }
    }
}
