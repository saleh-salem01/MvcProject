using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class UniqueAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ApplicationDbContext _connext = new ApplicationDbContext();
            if (value == null)
            {
                return ValidationResult.Success;
            }

            string name = (string)value;
            Course Crs= _connext.Courses.FirstOrDefault(c => c.Name == name);
            if ( Crs == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist");
        }
    }
}
