using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.Services;
using WPCTechnicalTest.Dto;

namespace WPCTechnicalTest.Pages;

public partial class CrimeSearch : IDisposable
{
    [Inject] protected IPoliceDataService PoliceDataService { get; set; } = default!;
   
    private LastCrimeDateDto? lastCrimeDate = default;

    //private readonly IPoliceDataService _policeDataService;

    //public Counter(IPoliceDataService policeDataService)
    //{
    //    _policeDataService = policeDataService;
    //}

    private async void IncrementCount()
    {
        var result = await PoliceDataService.GetLastCrimeUpdatedDate(CancellationToken.None);
        lastCrimeDate = result;

        var searchCriteria = new SearchCriteriaDto()
        {
            Latitude = "51.44237",
            Longitude = "-2.49810",
            Date = "2021-01"
        };
        var results = await PoliceDataService.GetCrimeDataByLocationAndDate(searchCriteria, CancellationToken.None);

        if (results != null && results.Any())
        {
            ProcessResults(results);
        }
        else
        {
            // TODO - Show no results banner
        }

        StateHasChanged();
    }

    private void ProcessResults(IEnumerable<CrimeDto>? results)
    {
        var groups = results
            .GroupBy(c => new { c.Category })
            .Select(c => new { c.Key.Category, Count = c.Count() });

        foreach (var group in groups) 
        { 
            Console.WriteLine($"{group.Category} - {group.Count}");
        }

        
    }

    public void Dispose()
    {

    }
}
