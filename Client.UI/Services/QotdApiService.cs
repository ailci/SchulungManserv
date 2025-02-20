using Logging;
using Shared.DataTransferObjects;

namespace Client.UI.Services;

public class QotdApiService(ILoggerManager logger, IHttpClientFactory clientFactory) 
    : IQotdApiService
{
    private const string QotdUri = "qotd";

    public async Task<QuoteOfTheDayDto> GetQuoteOfTheDayAsync()
    {
        logger.LogInformation($"{nameof(GetQuoteOfTheDayAsync)} aufgerufen...");

        var client = clientFactory.CreateClient("qotdapiservice");
        return await client.GetFromJsonAsync<QuoteOfTheDayDto>(QotdUri);
    }
}
