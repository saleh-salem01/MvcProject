using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        [ForeignKey("Course")]
        public int CrsId { get; set; }
        [ForeignKey("Student")]
        public int StudId { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
