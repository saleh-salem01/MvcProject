using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Instructor
    {
        #region Props

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        public double? Salary { get; set; }
        public string? Address { get; set; }
        [ForeignKey("department")]
        public int Dept_id { get; set; }
        public Department? department { get; set; }
        [ForeignKey("course")]
        public int CrsId { get; set; }
        public Course course { get; set; }
        #endregion

        public ApplicationDbContext dbContext = new ApplicationDbContext();

        public Instructor GetInstructor(int id)
        {
            return dbContext.Instructors.FirstOrDefault(e => e.Id == id);
        }
        public List<Instructor> GetAllInstructors()
        {
            return dbContext.Instructors.Select(e => e).ToList();
        }
    }
}
