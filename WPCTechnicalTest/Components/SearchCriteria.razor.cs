using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.Components;

public partial class SearchCriteria
{    
    [Parameter]
    public EventCallback<SearchCriteriaViewModel> OnSearch { get; set; }

    private readonly SearchCriteriaViewModel _model = new();
    private List<string>? _availableDates = default;

    protected override void OnInitialized()
    {
        _availableDates = BuildAvailableMonths().ToList();
    }

    private async void OnValidSubmit(EditContext context)
    {
        // Pass up the search criteria model to the parent component.
        await OnSearch.InvokeAsync(_model);

        StateHasChanged();
    }

    private void ResetTestData()
    {
        _model.Latitude = "51.44237";
        _model.Longitude = "-2.49810";
        _model.Date = "2023-10";
    }

    private static IEnumerable<string> BuildAvailableMonths()
    {
        var endDate = DateTime.UtcNow;
        var startDate = endDate.AddMonths(-12);

        var startYearMonth = $"{startDate.Year}-{startDate.Month}";
        var endYearMonth = $"{endDate.Year}-{endDate.Month}";

        string[] start = startYearMonth.Split('-');
        string[] end = endYearMonth.Split('-');

        DateTime startDT = new DateTime(int.Parse(start[0]), int.Parse(start[1]), 1);
        DateTime endDT = new DateTime(int.Parse(end[0]), int.Parse(end[1]), 1);

        while (startDT < endDT)
        {
            yield return $"{startDT.Year}-{startDT.Month.ToString("00")}"; ;
            startDT = startDT.AddMonths(1);
        }
    }
}
