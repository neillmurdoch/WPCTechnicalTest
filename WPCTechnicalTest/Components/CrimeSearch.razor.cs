using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.Services;

namespace WPCTechnicalTest.Components;

public partial class CrimeSearch
{
    [Inject] IPoliceDataService PoliceDataService { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {



    }
}
