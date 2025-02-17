using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")] // => localhost:1234/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    [HttpGet]  //=> localhost:1234/api/qotd
    public IActionResult GetQuoteOfTheDay()
    {
        var qotd = new QuoteOfTheDayDto
        {
            AuthorName = "Ich",
            AuthorDescription = "Dozent",
            AuthorBirthdate = DateOnly.FromDateTime(DateTime.Today),
            QuoteText = "Larum Lierum"
        };

        return Ok(qotd);
    }
}