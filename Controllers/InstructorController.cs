using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class InstructorController : Controller
    {
        Instructor instructor = new Instructor();

        #region ReturnActions
        public IActionResult ShowInstructor(int id)
        {
            Instructor Ins = instructor.GetInstructor(id);
            return View("ShowInstructorView", Ins);
        }
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult ShowAllInstructors()
        {
            //ViewBag["Crs"] = context.Courses.Select(x => x.Name);
            List<Instructor> Inses = instructor.GetAllInstructors();
            return View("ShowAllInstructorsView", Inses);
        }
        #endregion

        #region AddingAction
        public IActionResult NewIns()
        {
            return View(new Instructor());
        }
        [HttpPost]
        public IActionResult SaveChanges(Instructor Ins)
        {
            if (Ins.Name != null)
            {
                context.Instructors.Add(Ins);
                context.SaveChanges();
                List<Instructor> Inses = instructor.GetAllInstructors();
                return View("ShowAllInstructorsView", Inses);
            }

            return View("NewIns", Ins);
        }
        #endregion

        #region EditAction
        public IActionResult Edit(int id)
        {
            Instructor Ins = context.Instructors.FirstOrDefault(x => x.Id == id);
            return View("EditIns", Ins);
        }
        public IActionResult SaveEdit(int id,Instructor NewIns)
        {
            Instructor oldIns = context.Instructors.FirstOrDefault(x => x.Id == id);
            if (NewIns == null || NewIns.Name == null)
            {
                // Handle the case where Ins is null or Ins.Name is null
                return View("EditIns", NewIns);
            }
            else {     
                if (oldIns != null)
                {
                    oldIns.Name = NewIns.Name;
                    oldIns.Address = NewIns.Address;
                    oldIns.Salary = NewIns.Salary;
                    oldIns.Dept_id = NewIns.Dept_id;
                    oldIns.CrsId = NewIns.CrsId;
                    context.SaveChanges();
                   
                }
            }
            // List<Instructor> Inses = instructor.GetAllInstructors();
            return RedirectToAction("ShowAllInstructors");
        }
    }
        #endregion

    }

