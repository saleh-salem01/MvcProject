namespace MvcProject.Models
{
    public class Department
    {
        #region props
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Course>? Courses { get; set; }

        #endregion

        ApplicationDbContext ApplicationDb=new ApplicationDbContext();
        public Department GetDepartment(int id)
        {
            return ApplicationDb.Departments.FirstOrDefault(i => i.Id == id);
        }

        public List<Department> GetAllDepartments()
        {
            return ApplicationDb.Departments.Select(i=>i).ToList();
        }
    }
}
