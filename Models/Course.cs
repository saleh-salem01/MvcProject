using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        [ForeignKey("department")]
        public int DeptId { get; set; }
        public Department? department { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<CrsResult> crsResults { get; set; }

        

    }
}
