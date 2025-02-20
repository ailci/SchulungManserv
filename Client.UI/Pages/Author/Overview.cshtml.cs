using Client.UI.Services;
using Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DataTransferObjects;

namespace Client.UI.Pages.Author;

public class OverviewModel(ILoggerManager logger, IQotdApiService apiService) : PageModel
{
    public IEnumerable<AuthorDto> AuthorDtos { get; set; }

    public async Task OnGet()
    {
        AuthorDtos = await apiService.GetAuthorsAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        var deleted = await apiService.DeleteAuthorAsync(id);

        if(deleted) return RedirectToPage();

        return Page();
    }
}