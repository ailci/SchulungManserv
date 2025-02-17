﻿using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task<AuthorDto> GetAuthorAsync(Guid authorId);

}