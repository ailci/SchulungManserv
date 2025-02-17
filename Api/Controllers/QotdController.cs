using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")] // => localhost:1234/api/qotd
[ApiController]
public class QotdController : ControllerBase
{
    [HttpGet]  //=> localhost:1234/api/qotd
    public IActionResult GetQuoteOfTheDay()
    {
        var qotd = new Quote
        {
            QuoteText = "Larum lierum Löffelstiel, wer nicht fragt, der weiß nicht viel!",
            Author = new Author
            {
                Name = "Ich",
                Description = "Dozent",
                BirthDate = DateOnly.FromDateTime(DateTime.Today)
            }
        };

        return Ok(qotd);
    }
}