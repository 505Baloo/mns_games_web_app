using System.ComponentModel.DataAnnotations;

namespace mns_games_web_app.Services
{
    public class CustomSelectValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || (int)value == 0)
            {
                return new ValidationResult("Please select a valid value.");
            }
            return ValidationResult.Success;
        }
    }
}
