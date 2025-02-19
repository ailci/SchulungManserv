using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync(bool trackChanges);
    Task<AuthorDto> GetAuthorAsync(Guid authorId);
    Task<AuthorDto> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto);
    Task DeleteAuthorAsync(Guid authorId);
}