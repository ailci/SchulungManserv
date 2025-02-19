using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Validations;

[AttributeUsage(AttributeTargets.Property)]
public class NoFutureDateAttribute : ValidationAttribute
{
    public NoFutureDateAttribute()
    {
        if (string.IsNullOrEmpty(ErrorMessage)) ErrorMessage = "Datum liegt in der Zukunft";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //var dto = (AuthorForCreateDto) validationContext.ObjectInstance;
        if (value is DateOnly dateToCheck)
        {
            if (dateToCheck >= DateOnly.FromDateTime(DateTime.Today))
                return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}