using System.Drawing;

namespace MvcProject.ViewModel
{
    public class StudentCourseViewModel
    {
        public string StudentName { get; set; }
        public string StudentImage { get; set; }

        public List<CourseDetail> Courses { get; set; } = new List<CourseDetail>();
    }

    public class CourseDetail
    {
      
        public string CourseName { get; set; }
        public int CourseDegree { get; set; }
        public int MaxGrade { get; set; }
        public int MinGrade { get; set; }
        public bool IsBelowMinGrade => CourseDegree < MinGrade;
        public bool IsAboveMinGrade => CourseDegree > MinGrade;


    }

    }

