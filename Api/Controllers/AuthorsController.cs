using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    #region Member/Constructor

    private readonly IServiceManager _serviceManager;

    public AuthorsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    #endregion

    #region GET

    public async Task<IActionResult> Get()
    {
        var authorDtos = await _serviceManager.AuthorService.GetAuthorsAsync();
        return Ok(authorDtos);
    }

    #endregion
}