using Api.Filter;
using Domain.Entities;
using Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contracts;
using Services;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")] // => localhost:1234/api/qotd
[ApiController]
public class QotdController(IServiceManager serviceManager, ILoggerManager logger) : ControllerBase
{
    [HttpGet]  //=> localhost:1234/api/qotd
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetQuoteOfTheDay()
    {
       logger.LogInformation($"{nameof(GetQuoteOfTheDay)} wurde aufgerufen...");
       
       return Ok(await serviceManager.QotdService.GetQuoteOfTheDayAsync(false));
    }
    
    [HttpGet("secured")]  //=> localhost:1234/api/qotd/secured
    [ServiceFilter(typeof(ApiKeyAuthFilterAttribute))] // via Filter
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetQuoteOfTheDaySecured()
    {
       logger.LogInformation($"{nameof(GetQuoteOfTheDaySecured)} wurde aufgerufen...");
       
       return Ok(await serviceManager.QotdService.GetQuoteOfTheDayAsync(false));
    }
}