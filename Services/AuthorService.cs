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

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync(bool trackChanges)
    {
        var authors = await _repositoryManager.AuthorRepo.GetAuthorsAsync(trackChanges);

        return _mapper.Map<IEnumerable<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> GetAuthorAsync(Guid authorId)
    {
        var authorEntity = await GetAuthorAndCheckIfItExistsAsync(authorId);
        return _mapper.Map<AuthorDto>(authorEntity);
    }

    public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreateDto authorForCreateDto)
    {
        var authorEntity = _mapper.Map<Author>(authorForCreateDto);

        _repositoryManager.AuthorRepo.CreateAuthor(authorEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<AuthorDto>(authorEntity);
    }

    public async Task DeleteAuthorAsync(Guid authorId)
    {
        var authorEntity = await GetAuthorAndCheckIfItExistsAsync(authorId);
        _repositoryManager.AuthorRepo.DeleteAuthor(authorEntity);
        await _repositoryManager.SaveAsync();
    }

    private async Task<Author> GetAuthorAndCheckIfItExistsAsync(Guid authorId)
    {
        var author = await _repositoryManager.AuthorRepo.GetAuthorAsync(authorId);

        if (author is null) throw new AuthorNotFoundException(authorId);

        return author;
    }
}