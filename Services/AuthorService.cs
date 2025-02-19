using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Persistence.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public AuthorService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        var authors = await _repositoryManager.AuthorRepo.GetAuthorsAsync();

        return _mapper.Map<IEnumerable<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid authorId)
    {
        var authorEntity = await GetAuthorAndCheckIfItExistsAsync(authorId);
        return _mapper.Map<AuthorDto>(authorEntity);
    }

    private async Task<Author> GetAuthorAndCheckIfItExistsAsync(Guid authorId)
    {
        var author = await _repositoryManager.AuthorRepo.GetAuthorAsync(authorId);

        if (author is null) throw new AuthorNotFoundException(authorId);

        return author;
    }
}