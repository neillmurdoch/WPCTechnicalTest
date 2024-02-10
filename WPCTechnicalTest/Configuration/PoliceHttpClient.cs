namespace WPCTechnicalTest.Configuration;

public class PoliceHttpClient : IPoliceHttpClient
{
    public PoliceHttpClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public HttpClient HttpClient { get; }
}
