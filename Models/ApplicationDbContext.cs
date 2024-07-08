using Microsoft.EntityFrameworkCore;

namespace MvcProject.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        //public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-8386INR;Initial Catalog=MvcProject;Integrated Security=True;TrustServerCertificate=True;");
        }

    }
}
