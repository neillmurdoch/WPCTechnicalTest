namespace WPCTechnicalTest.Configuration;

internal class PoliceHttpClient : IPoliceHttpClient
{
    public PoliceHttpClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public HttpClient HttpClient { get; }
}
