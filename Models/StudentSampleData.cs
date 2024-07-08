namespace MvcProject.Models
{
    public class StudentSampleData
    {
        public List<Student> Students;
        public StudentSampleData()
        {
            Students = new List<Student>();
            Students.Add(new Student() { ID = 1, Name = "Saleh Salem", Address = "Mokkatem", Image = "1.jpg" });
            Students.Add(new Student() { ID = 2, Name = "Ali Walid", Address = "Mokkatem", Image = "2.jpg" });
           Students.Add(new Student() { ID = 3, Name = "Mohamed Ashraf", Address = "Mokkatem", Image = "3.jpg" });
            //Students.Add(new Student() { ID = 4, Name = "Omnia Fathi", Address = "Mokkatem", Image = "" });
            //Students.Add(new Student() { ID = 5, Name = "Malak Ashraf", Address = "Mokkatem", Image = "" });
        }

        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(i => i.ID == id);
        }

        public List<Student> GetStudents()
        {
            return Students;
        }
    }
}