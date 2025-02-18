using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Services;

public class QotdService : IQotdService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public QotdService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        var randomQuote = await _repositoryManager.QuoteRepo.GetRandomQuoteAsync();

        //return new QuoteOfTheDayDto
        //{
        //    AuthorName = randomQuote.Author?.Name,
        //    AuthorDescription = randomQuote.Author?.Description ?? "k.A.",
        //    AuthorBirthdate = randomQuote.Author?.BirthDate,
        //    AuthorPhoto = randomQuote.Author?.Photo,
        //    AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType,
        //    QuoteText = randomQuote.QuoteText,
        //    Id = randomQuote.Id
        //};

        //Automapper Variante
        return _mapper.Map<QuoteOfTheDayDto>(randomQuote);
    }
}