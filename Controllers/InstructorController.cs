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
            Instructor ins = context.Instructors.FirstOrDefault(x => x.Id == id);
            if (ins == null)
            {

                return NotFound();
            }
            return View("EditIns", ins);
        }

 

        [HttpPost]
        public IActionResult SaveEdit(int id, Instructor newIns)
        {
            if (newIns == null || string.IsNullOrEmpty(newIns.Name))
            {
                ModelState.AddModelError("", "Invalid instructor details.");
                return View("EditIns", newIns);
            }

            Instructor oldIns = context.Instructors.FirstOrDefault(x => x.Id == id);
            if (oldIns != null)
            {
                oldIns.Name = newIns.Name;
                oldIns.Address = newIns.Address;
                oldIns.Salary = newIns.Salary;
                oldIns.Dept_id = newIns.Dept_id;
                oldIns.CrsId = newIns.CrsId;
                context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Instructor not found.");
                return View("EditIns", newIns);
            }

            return RedirectToAction("ShowAllInstructors");
        }
        #endregion
        #region Delete Actions
        public IActionResult Delete(int id)
        {
            Instructor DIns = context.Instructors.FirstOrDefault(n => n.Id == id);
            return View(DIns);
        }
        public IActionResult SaveDelete(int id) 
        {
            Instructor DIns = context.Instructors.FirstOrDefault(n=>n.Id== id);
            if (DIns != null)
            {
                context.Instructors.Remove(DIns);
                context.SaveChanges();
                
            }
            return RedirectToAction("ShowAllInstructors");
        }
        #endregion
    }
    


}





