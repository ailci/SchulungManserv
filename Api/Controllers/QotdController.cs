using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contracts;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")] // => localhost:1234/api/qotd
[ApiController]
public class QotdController(IRepositoryManager manager) : ControllerBase
{
    [HttpGet]  //=> localhost:1234/api/qotd
    public async Task<IActionResult> GetQuoteOfTheDay()
    {
        var randomQuote = await manager.QuoteRepo.GetRandomQuoteAsync();

        var qotd = new QuoteOfTheDayDto
        {
            AuthorName = randomQuote.Author?.Name,
            AuthorDescription = randomQuote.Author?.Description ?? "k.A.",
            AuthorBirthdate = randomQuote.Author?.BirthDate,
            AuthorPhoto = randomQuote.Author?.Photo,
            AuthorPhotoMimeType = randomQuote.Author?.PhotoMimeType,
            QuoteText = randomQuote.QuoteText,
            Id = randomQuote.Id
        };
        
        return Ok(qotd);
    }
}