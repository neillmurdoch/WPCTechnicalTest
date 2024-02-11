using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.Services;

namespace WPCTechnicalTest.Components;

public partial class SearchCriteria
{
    [Inject] IPoliceDataService PoliceDataService { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {



    }
}
