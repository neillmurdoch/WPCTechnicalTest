using Microsoft.AspNetCore.Components;
using System.Data;
using WPCTechnicalTest.Dto;
using WPCTechnicalTest.Services;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.Components;

public partial class CrimeSearch
{
    [Inject] IPoliceDataService PoliceDataService { get; set; } = default!;

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
            CrimesSummary = MapResultsToCategorySummaryViewModels(results);
        }

        LoadingResults = false;
        SearchPerformed = true;

        // This will re-render any child components with linked parameters.
        StateHasChanged();
    }

    private List<CategorySummaryViewModel> MapResultsToCategorySummaryViewModels(List<CrimeDto>? results)
    {
        if (results == null) return [];

        var groups = results
            .GroupBy(c => new { c.Category })
            .Select(c => new { c.Key.Category, Count = c.Count() });

        var viewModels = new List<CategorySummaryViewModel>();

        foreach (var group in groups)
        {
            viewModels.Add(new CategorySummaryViewModel()
            {
                Category = group.Category == null ? "Unknown" : group.Category,
                Count = group.Count
            });
        }

        return viewModels;
    }
}
