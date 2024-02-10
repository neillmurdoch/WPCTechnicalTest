namespace WPCTechnicalTest.Services;

internal abstract class ServiceBase
{
    private readonly HttpClient _httpClient;

    public ServiceBase(HttpClient httpClient) //, IJsonHelper jsonHelper)
    {
        _httpClient = httpClient;
    }

    protected abstract string EndPoint { get; }

    protected async Task<HttpResponseMessage> ExecuteRequestAsync(string requestUrl)//, CancellationToken cancellationToken)
    {
        return await _httpClient.GetAsync(requestUrl);//, cancellationToken);
    }
}
