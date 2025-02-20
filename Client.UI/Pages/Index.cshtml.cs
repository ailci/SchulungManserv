using Client.UI.Services;
using Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DataTransferObjects;
using System.Text.Json;

namespace Client.UI.Pages;

public class IndexModel : PageModel
{
    private readonly ILoggerManager _logger;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IQotdApiService _apiService;

    public QuoteOfTheDayDto? QotdDto { get; set; }

    public IndexModel(ILoggerManager logger, IHttpClientFactory clientFactory, IQotdApiService apiService)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _apiService = apiService;
    }

    public async Task OnGet()
    {
        _logger.LogInformation("OnGet aufgerufen...");

        try
        {
            // 1. Version Klassik
            //var client = _clientFactory.CreateClient("qotdapiservice");
            //var response = await client.GetAsync("qotd");
            //response.EnsureSuccessStatusCode();
            //var content = await response.Content.ReadAsStringAsync();
            //QotdDto = JsonSerializer.Deserialize<QuoteOfTheDayDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            // 2.Version Netter
            //var client = _clientFactory.CreateClient("qotdapiservice");
            //QotdDto = await client.GetFromJsonAsync<QuoteOfTheDayDto>("qotd");

            // 3. Version mit Service
            //QotdDto = await _apiService.GetQuoteOfTheDayAsync();

            // 4. Version mit Service und Api-Key
            QotdDto = await _apiService.GetQuoteOfTheDaySecuredAsync();

        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"{ex.StatusCode} ### {ex.Message}");
        }
    }
}
