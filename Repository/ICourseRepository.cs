using MvcProject.Models;

namespace MvcProject.Repository
{
    public interface ICourseRepository
    {
        public void SaveCourseChanges(Course Crs);
        public void SaveEdit(int id, Course newCrs);
        public Course GetCourse(int id);
        public List<Course> GetAllCourses();
    }
}
