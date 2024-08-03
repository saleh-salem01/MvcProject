using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;

namespace MvcProject.Repository
{
    public class CourseRepository : ICourseRepository
    {

        //Course course = new Course();
       
        ApplicationDbContext _context = new ApplicationDbContext();
        public Course GetCourse(int id)
        {
            return _context.Courses.FirstOrDefault(i => i.Id == id);
        }
        public List<Course> GetAllCourses()
        {
            List<Course> lis = _context.Courses.Select(i => i).ToList();
            return lis;
        }

        #region AddingAction


        public void SaveCourseChanges(Course Crs)
        {
            if (Crs.Name != null)
            {
                _context.Courses.Add(Crs);
                _context.SaveChanges();
            }
        }
        #endregion
        #region edit

        public void SaveEdit(int id, Course newCrs)
        {

            Course oldCourse = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (oldCourse != null)
            {
                oldCourse.Name = newCrs.Name;
                oldCourse.Degree = newCrs.Degree;
                oldCourse.MinDegree = newCrs.MinDegree;
                oldCourse.DeptId = newCrs.DeptId;

                _context.SaveChanges();
            }
       
        }
        #endregion
    
    }
}
