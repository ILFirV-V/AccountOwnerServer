using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Attributes
{
    public class DateOfBirthRangeAttribute : ValidationAttribute
    {
        private readonly string maxYearOfBirthPropertyName;

        public DateOfBirthRangeAttribute(string maxYearOfBirthPropertyName)
        {
            this.maxYearOfBirthPropertyName = maxYearOfBirthPropertyName;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (!(value is DateTime minYearOfBirth))
            {
                return new ValidationResult("Дата рождения 'Начиная с' должна быть датой.");
            }

            var maxYearOfBirthProperty = validationContext.ObjectType.GetProperty(maxYearOfBirthPropertyName);
            if (maxYearOfBirthProperty == null)
            {
                return new ValidationResult($"Свойство {maxYearOfBirthPropertyName} не найдено.");
            }

            var maxYearOfBirthValue = maxYearOfBirthProperty.GetValue(validationContext.ObjectInstance);

            if (maxYearOfBirthValue == null)
            {
                return new ValidationResult($"Свойство {maxYearOfBirthPropertyName} не должно быть пустым.");
            }

            if (!(maxYearOfBirthValue is DateTime maxYearOfBirth))
            {
                return new ValidationResult("Дата рождения 'Заканчивая с' должна быть датой.");
            }

            if (minYearOfBirth >= maxYearOfBirth)
            {
                return new ValidationResult($"Дата рождения 'Начиная с' должна быть меньше, чем дата рождения 'Заканчивая с'.");
            }

            return ValidationResult.Success;
        }
    }
}
