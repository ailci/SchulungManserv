using Logging;
using Microsoft.Extensions.Options;
using Shared.DataTransferObjects;

namespace Client.UI.Services;

public class QotdApiService(ILoggerManager logger, HttpClient client, IOptions<QotdAppSettings> appSettings) 
    : IQotdApiService
{
    private readonly QotdAppSettings _appSettings = appSettings.Value;
    private const string QotdUri = "qotd";
    private const string QotdSecuredUri = "qotd/secured";
    private const string QotdAuthorsUri = "authors";

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");
        
        return await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdUri);
    }
    
    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDaySecuredAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDaySecuredAsync)} aufgerufen...");
        
        //client.DefaultRequestHeaders.Add("x-api-key", _appSettings.XApiKey);
        
        return await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdSecuredUri);
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        logger.LogInformation($"{nameof(GetAuthorsAsync)} aufgerufen...");

        return await client.GetFromJsonAsync<IEnumerable<AuthorDto>>(QotdAuthorsUri);
    }

    public async Task<bool> DeleteAuthorAsync(Guid authorId)
    {
        var response = await client.DeleteAsync($"{QotdAuthorsUri}/{authorId}");

        return response.IsSuccessStatusCode;
    }
}
