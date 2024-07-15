﻿using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class InstructorController : Controller
    {
        Instructor instructor = new Instructor();
        public IActionResult ShowInstructor(int id)
        {
            Instructor Ins = instructor.GetInstructor(id);   
            return View("ShowInstructorView",Ins);
        }
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult ShowAllInstructors()
        {
            //ViewBag["Crs"] = context.Courses.Select(x => x.Name);
            List<Instructor> Inses = instructor.GetAllInstructors();
            return View("ShowAllInstructorsView", Inses);
        }
    }
}
