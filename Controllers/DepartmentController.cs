using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class DepartmentController : Controller
    {
        Department Department = new Department();
        public IActionResult ShowDepartment(int id)
        {
            Department Dept = Department.GetDepartment(id);
            return View("ShowDepartmentView",Dept);
        }
        public IActionResult ShowAllDepartments(int id)
        {
            List<Department> Depts = Department.GetAllDepartments();
            return View("ShowAllDepartmentsView", Depts);
        }
    }
}
