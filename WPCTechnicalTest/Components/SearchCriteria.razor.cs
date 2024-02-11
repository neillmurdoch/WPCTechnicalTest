using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using WPCTechnicalTest.Services;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.Components;

public partial class SearchCriteria
{    
    [Parameter]
    public EventCallback<SearchCriteriaViewModel> OnSearch { get; set; }

    SearchCriteriaViewModel model = new();

    private async void OnValidSubmit(EditContext context)
    {
        // Pass up the search criteria model to the parent component.
        await OnSearch.InvokeAsync(model);

        StateHasChanged();
    }
}
