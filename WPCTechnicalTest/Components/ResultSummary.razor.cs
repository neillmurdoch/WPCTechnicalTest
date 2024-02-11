using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.Services;

namespace WPCTechnicalTest.Components;

public partial class ResultSummary
{
    [Inject] IPoliceDataService PoliceDataService { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {



    }
}
