using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Services;

public class QotdService : IQotdService
{
    private readonly IRepositoryManager _repositoryManager;

    public QotdService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        var randomQuote = await _repositoryManager.QuoteRepo.GetRandomQuoteAsync();

        return new QuoteOfTheDayDto
        {
            AuthorName = randomQuote.Author?.Name,
            AuthorDescription = randomQuote.Author?.Description ?? "k.A.",
            AuthorBirthdate = randomQuote.Author?.BirthDate,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType,
            QuoteText = randomQuote.QuoteText,
            Id = randomQuote.Id
        };
    }
}