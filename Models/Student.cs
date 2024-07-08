using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public double Grade { get; set; }
        [ForeignKey("department")]
        public int DeptId { get; set; }
        public Department? department { get; set; }
        public ICollection<CrsResult> crsResults { get; set; }
    }
}
