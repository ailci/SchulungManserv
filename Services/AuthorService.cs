using AutoMapper;
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
}