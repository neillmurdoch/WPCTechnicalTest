using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WPCTechnicalTest.Helpers;
using WPCTechnicalTest.Services;

namespace WPCTechnicalTest.Extensions;

public static class CustomServiceExtensions
{
    public static WebAssemblyHostBuilder AddCustomServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped<IPoliceDataService, PoliceDataService>();
        builder.Services.AddScoped<ICrimeSearchHelper, CrimeSearchHelper>();

        return builder;
    }
}
