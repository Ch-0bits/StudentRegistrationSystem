
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class AgeAbove18Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Perform your custom validation logic here
            DateTime dateValue = Convert.ToDateTime(value);
            DateTime minValue = DateTime.Now.AddYears(-18);

            if (dateValue > minValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
             
}
