using Microsoft.AspNetCore.Components;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.Components;

public partial class ResultSummary
{
    [Parameter] public List<CategorySummaryViewModel>? CrimesSummary { get; set; } = null;
    [Parameter] public bool LoadingResults { get; set; } = true;
    [Parameter] public bool SearchPerformed { get; set; } = false;
}
