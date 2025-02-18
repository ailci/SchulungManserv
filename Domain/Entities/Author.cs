﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Author
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateOnly? BirthDate { get; set; }
    public byte[]? Photo { get; set; }
    public string? PhotoMimeType { get; set; }
    public ICollection<Quote>? Quotes { get; set; }
}