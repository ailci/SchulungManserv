using Domain.Entities;
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
public class QotdController(IServiceManager serviceManager) : ControllerBase
{
    [HttpGet]  //=> localhost:1234/api/qotd
    public async Task<IActionResult> GetQuoteOfTheDay()
    {
       return Ok(await serviceManager.QotdService.GetQuoteOfTheDayAsync());
    }
}