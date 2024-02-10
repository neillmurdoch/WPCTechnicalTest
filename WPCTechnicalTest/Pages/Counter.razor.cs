using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.Services;
using WPCTechnicalTest.Dto;

namespace WPCTechnicalTest.Pages;

public partial class Counter : IDisposable
{
    [Inject] protected IPoliceDataService PoliceDataService { get; set; } = default!;
   
    private int currentCount = 0;
    private string lastCrimeDate = string.Empty;

    //private readonly IPoliceDataService _policeDataService;

    //public Counter(IPoliceDataService policeDataService)
    //{
    //    _policeDataService = policeDataService;
    //}

    private async void IncrementCount()
    {
        var result = await PoliceDataService.GetLastCrimeUpdatedDate();
        lastCrimeDate = result;

        var searchCriteria = new SearchDto()
        {
            Latitude = "51.44237",
            Longitude = "-2.49810",
            Date = "2021-01"
        };
        var results = await PoliceDataService.GetCrimeDataByLocationAndDate(searchCriteria);


        currentCount++;

        StateHasChanged();
    }

    public void Dispose()
    {

    }
}
