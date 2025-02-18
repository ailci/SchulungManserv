using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects;

public class AuthorDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public DateOnly? BirthDate { get; init; }
    public byte[]? Photo { get; init; }
    public string? PhotoMimeType { get; init; }
}