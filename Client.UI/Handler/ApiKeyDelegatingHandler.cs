using Microsoft.Extensions.Options;

namespace Client.UI.Handler;

public class ApiKeyDelegatingHandler(IOptions<QotdAppSettings> appSettings) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("x-api-key", appSettings.Value.XApiKey);

        return base.SendAsync(request, cancellationToken);
    }
}
