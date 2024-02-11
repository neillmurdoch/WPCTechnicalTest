using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.Services;

namespace WPCTechnicalTest.Components;

public partial class LastCrimeDate
{
    [Inject] IPoliceDataService PoliceDataService { get; set; } = default!;

    internal bool Initializing { get; set; } = true;
    internal string LastUpdateDate { get; set; } = default!;
    internal bool UpdateDateNotAvailable { get; set; }

    protected async override Task OnInitializedAsync()
    {
        var result = await PoliceDataService.GetLastCrimeUpdatedDate(CancellationToken.None);
        if (result == null)
        {
            UpdateDateNotAvailable = true;
        }
        else
        {
            LastUpdateDate = result.LastCrimeDate.ToLongDateString();
            UpdateDateNotAvailable = false;
        }
        Initializing = false;
    }
}
