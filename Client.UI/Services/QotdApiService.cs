using Logging;
using Shared.DataTransferObjects;

namespace Client.UI.Services;

public class QotdApiService(ILoggerManager logger, HttpClient client) 
    : IQotdApiService
{
    private const string QotdUri = "qotd";

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        return await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdUri);
    }
}
