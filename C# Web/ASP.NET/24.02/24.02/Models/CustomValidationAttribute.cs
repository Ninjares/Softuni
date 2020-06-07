using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _24._02.Models
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value! is string) return new ValidationResult("object is not string");
            else return new ValidationResult("what now?");
        }
    }
}
