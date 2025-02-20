using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DataTransferObjects;

namespace Client.UI.Pages.Author;

public class OverviewModel : PageModel
{
    public IEnumerable<AuthorDto> AuthorDtos { get; set; }

    public void OnGet()
    {
    }
}