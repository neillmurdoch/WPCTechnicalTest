using Microsoft.AspNetCore.WebUtilities;
using System.Runtime.CompilerServices;
using System.Text.Json;
using WPCTechnicalTest.Dto;

[assembly: InternalsVisibleTo("WPCTechnicalTest.UnitTests")]

namespace WPCTechnicalTest.Services;

internal class PoliceDataService(IHttpClientFactory httpClientFactory) : IPoliceDataService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("PoliceData");

    /// <summary>
    /// Return the date that the crime data was last updated
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>LastCrimeDateDto with a LastCrimeDate property</returns>
    public async Task<LastCrimeDateDto?> GetLastCrimeUpdatedDate(CancellationToken cancellationToken)
    {
        const string apiUrl = "api/crime-last-updated";

        var response = await _httpClient.GetAsync(apiUrl, cancellationToken);
        try
        {
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync(cancellationToken);          
            var result = JsonSerializer.Deserialize<LastCrimeDateDto>(body);
            if (result?.LastCrimeDate == DateTime.MinValue)
            {
                return default;
            }

            return result;
        }
        catch
        { 
            return default;
        }
    }

    /// <summary>
    /// Accepts search criteria (latitude, longitude and date), and return a list of crimes committed with a mile radius of the location, for that month
    /// </summary>
    /// <param name="searchCriteria"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A list of crime objects for the requested location and date</returns>
    public async Task<List<CrimeDto>?> GetCrimeDataByLocationAndDate(SearchCriteriaDto searchCriteria, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(searchCriteria);
        ArgumentNullException.ThrowIfNull(searchCriteria.Latitude);
        ArgumentNullException.ThrowIfNull(searchCriteria.Longitude);
        ArgumentNullException.ThrowIfNull(searchCriteria.Date);

        var parameters = BuildParameterDictionary(searchCriteria);

        var apiUrl = QueryHelpers.AddQueryString("api/crimes-street/all-crime", parameters);
        
        var response = await _httpClient.GetAsync(apiUrl, cancellationToken);

        try
        {
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonSerializer.Deserialize<List<CrimeDto>>(body);

            return result;
        }
        catch
        {
            return default;
        }
    }

    #region Helpers

    private static Dictionary<string, string?> BuildParameterDictionary(SearchCriteriaDto searchCriteria)
    {
        var parameters = new Dictionary<string, string?>
        {
            ["lat"] = searchCriteria.Latitude,
            ["lng"] = searchCriteria.Longitude,
            ["date"] = searchCriteria.Date
        };
        return parameters;
    }

    #endregion
}
