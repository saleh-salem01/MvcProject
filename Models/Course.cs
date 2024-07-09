using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MvcProject.Models
{
    public class Course
    {
        #region Props
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        [ForeignKey("department")]
        public int DeptId { get; set; }
        public Department? department { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<CrsResult> crsResults { get; set; }
        #endregion

        ApplicationDbContext applicationDb = new ApplicationDbContext();

        public Course GetCourse(int id)
        {
            return applicationDb.Courses.FirstOrDefault(i => i.Id == id);
        }
        public List<Course> GetAllCourses()
        {
            List<Course> lis = applicationDb.Courses.Select(i => i).ToList();
            return lis;
        }
    } 
}
