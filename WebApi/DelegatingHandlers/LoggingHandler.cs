namespace WebApi.DelegatingHandlers;

public class LoggingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Request: {Method} {Uri}", request.Method, request.RequestUri);

            var result = await base.SendAsync(request, cancellationToken);
            result.EnsureSuccessStatusCode();

            //Console.WriteLine(result.Content.ReadAsStringAsync().Result);

            _logger.LogInformation("After Request");

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "HTTP request failed");

            throw;
        }
    }
}
