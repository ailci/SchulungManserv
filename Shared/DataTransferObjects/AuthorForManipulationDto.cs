using Microsoft.AspNetCore.Http;
using Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects;

public abstract class AuthorForManipulationDto
{
    [Required(ErrorMessage = "Bitte geben Sie eine Namen ein!")]
    [MaxLength(100, ErrorMessage = "Der Name darf 100 Zeichen nicht überschreiten")]
    [DeniedValues(["administrator","root","admin","god"], ErrorMessage = "Der Name ist nicht erlaubt")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie eine Description ein!")]
    public string? Description { get; set; }

    [NoFutureDate(ErrorMessage = "Geburtsdatum liegt in der Zukunft")]
    public DateOnly? BirthDate { get; set; }
    public IFormFile? Photo { get; set; }
}