using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Validations;

//public class AllowedExtensionsAttribute(params string[] allowedExtensions) : ValidationAttribute
//{
//    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//    {
//        if (value is IFormFile formFile && allowedExtensions.Contains(Path.GetExtension(formFile.FileName).Trim('.')))
//        {
//            return ValidationResult.Success;
//        }

//        return new ValidationResult("File-Type not allowed");
//    }
//}

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private IEnumerable<string> AllowedExtensions { get; set; }

    public AllowedExtensionsAttribute(params string[] valideTypen)
    {
        AllowedExtensions = valideTypen.Select(c => c.Trim().ToLower());
        ErrorMessage = $"Nur folgende Datei-Typen sind erlaubt: {string.Join(",", AllowedExtensions)}";
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        //MVC, RazorPages
        if (value is IFormFile formFile && !AllowedExtensions.Any(c => formFile.FileName.EndsWith(c)))
        {
            return new ValidationResult(ErrorMessage, [validationContext.MemberName]!);
        }

        return ValidationResult.Success;
    }
}