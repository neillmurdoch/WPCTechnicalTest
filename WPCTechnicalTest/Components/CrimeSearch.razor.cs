using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.Dto;
using WPCTechnicalTest.Helpers;
using WPCTechnicalTest.Services;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.Components;

public partial class CrimeSearch
{
    [Inject] IPoliceDataService PoliceDataService { get; set; } = default!;
    [Inject] ICrimeSearchHelper CrimeSearchHelper { get; set; } = default!;

    internal List<CategorySummaryViewModel>? CrimesSummary { get; set; }
    internal bool LoadingResults { get; set; }
    internal bool SearchPerformed { get; set; }
    internal bool SearchNotAvailable { get; set; }

    public async Task OnSearch(SearchCriteriaViewModel searchCriteria)
    {
        LoadingResults = true;

        // Map the view model to a dto
        var searchCriteriaDto = new SearchCriteriaDto()
        {
            Latitude = searchCriteria.Latitude,
            Longitude = searchCriteria.Longitude,
            Date = searchCriteria.Date
        };

        var results = await PoliceDataService.GetCrimeDataByLocationAndDate(searchCriteriaDto, CancellationToken.None);
        if (results == null)
        {
            SearchNotAvailable = true;
        }
        else
        {
            CrimesSummary = CrimeSearchHelper.MapResultsToCategorySummaryViewModels(results);
        }

        LoadingResults = false;
        SearchPerformed = true;

        // This will re-render any child components with linked parameters.
        StateHasChanged();
    }
}
