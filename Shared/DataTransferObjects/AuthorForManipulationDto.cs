using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects;

public abstract class AuthorForManipulationDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? BirthDate { get; set; }
    public IFormFile? Photo { get; set; }
}