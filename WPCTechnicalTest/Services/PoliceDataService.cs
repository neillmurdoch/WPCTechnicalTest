using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using WPCTechnicalTest.Dto;

namespace WPCTechnicalTest.Services;

internal class PoliceDataService(IHttpClientFactory httpClientFactory) : IPoliceDataService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("PoliceData");

    public async Task<string> GetLastCrimeUpdatedDate()
    {
        const string apiUrl = "api/crime-last-updated";

        var response = await _httpClient.GetAsync(apiUrl);//, cancellationToken);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();

        return body;
    }

    //public async Task<IEnumerable<CrimeDto>> GetCrimeDataByLocationAndDate(string latitude, string longitude, string date)
    public async Task<IEnumerable<CrimeDto>> GetCrimeDataByLocationAndDate(SearchDto searchCriteria)
    {
        //var parameters = BuildParameterDictionary(latitude, longitude, date);
        var parameters = BuildParameterDictionary(searchCriteria);

        var apiUrl = QueryHelpers.AddQueryString("api/crimes-street/all-crime", parameters);
        
        var response = await _httpClient.GetAsync(apiUrl);//, cancellationToken);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<IEnumerable<CrimeDto>>(body);

        return results;
    }

    //private Dictionary<string, string?> BuildParameterDictionary(string latitude, string longitude, string date)
    private Dictionary<string, string?> BuildParameterDictionary(SearchDto searchCriteria)
    {
        var parameters = new Dictionary<string, string?>
        {
            ["lat"] = searchCriteria.Latitude,
            ["lng"] = searchCriteria.Longitude,
            ["date"] = searchCriteria.Date
        };
        return parameters;
    }
}
