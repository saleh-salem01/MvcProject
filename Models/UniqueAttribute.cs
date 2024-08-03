using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models
{
    public class UniqueAttribute :ValidationAttribute
    {
        ApplicationDbContext _connext =  new ApplicationDbContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            Course Crs= _connext.Courses.FirstOrDefault(c => c.Name == value);
            if ( Crs == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist");
        }
    }
}
