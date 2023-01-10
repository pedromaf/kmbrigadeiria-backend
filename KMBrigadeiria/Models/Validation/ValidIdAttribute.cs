using KMBrigadeiria.Models.Enums;
using KMBrigadeiria.Resources;
using KMBrigadeiria.Util;
using System.ComponentModel.DataAnnotations;

namespace KMBrigadeiria.Models.Validation
{
    public class ValidIdAttribute : ValidationAttribute
    {
        public ValidIdAttribute() : base(StringMessages.INVALID_ID_ATTRIBUTE)
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var id = (long)value;

            if (value == null || id <= 0)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);

                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
