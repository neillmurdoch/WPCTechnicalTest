using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WPCTechnicalTest.Extensions;

public static class HttpClientExtensions
{
    public static WebAssemblyHostBuilder AddHttpClients(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddHttpClient("PoliceData", httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://data.police.uk");
        });

        return builder;
    }
}
