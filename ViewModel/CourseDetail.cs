namespace MvcProject.ViewModel
{
    public class StudentCourseViewModel
    {
        public string StudentName { get; set; }
        public List<CourseDetail> Courses { get; set; }
    }

    public class CourseDetail
    {
        public string CourseName { get; set; }
        public int CourseDegree { get; set; }
        public int MaxGrade { get; set; }
        public int MinGrade { get; set; }
    }
}
