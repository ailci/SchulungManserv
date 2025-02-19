using Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared.DataTransferObjects;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    #region Member/Constructor

    private readonly IServiceManager _serviceManager;
    private readonly ILoggerManager _logger;

    public AuthorsController(IServiceManager serviceManager, ILoggerManager logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    #endregion

    #region GET

    [HttpGet(Name = "GetAuthors")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Get Autoren aufgerufen...");
        var authorDtos = await _serviceManager.AuthorService.GetAuthorsAsync();
        return Ok(authorDtos);
    }

    [HttpGet("{id:guid}", Name = "GetAuthor")]  // => localhost:1234/api/authors/{id}
    public async Task<IActionResult> GetAuthor(Guid id)
    {
        var authorDto = await _serviceManager.AuthorService.GetAuthorAsync(id);

        //if (authorDto is null) return NotFound();

        return Ok(authorDto);
    }

    #endregion

    #region POST

    [HttpPost(Name = "CreateAuthor")]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreateDto authorForCreateDto)
    {
        var authorDto = await _serviceManager.AuthorService.CreateAuthorAsync(authorForCreateDto);

        return CreatedAtRoute("GetAuthor", new { id = authorDto.Id }, authorDto);
    }

    #endregion
}