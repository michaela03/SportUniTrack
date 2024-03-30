using System.ComponentModel.DataAnnotations;

namespace SportUniTrack.Models
{
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        //[RequiredIfStudent(ErrorMessage = "Полето {0} е задължително.")]
        public string FacultyNumber { get; set; } 
        public string Speciality { get; set; }
    }

    public class RequiredIfStudentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (ApplicationUser)validationContext.ObjectInstance;
            if (user.Role == "Student")
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
