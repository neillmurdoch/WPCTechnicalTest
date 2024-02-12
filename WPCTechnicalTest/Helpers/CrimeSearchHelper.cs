using WPCTechnicalTest.Dto;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.Helpers;

internal class CrimeSearchHelper : ICrimeSearchHelper
{
    public List<CategorySummaryViewModel> MapResultsToCategorySummaryViewModels(List<CrimeDto>? crimeResults)
    {
        if (crimeResults == null) return [];

        var groups = crimeResults
            .GroupBy(c => new { c.Category })
            .Select(c => new { c.Key.Category, Count = c.Count() });

        var viewModels = new List<CategorySummaryViewModel>();

        foreach (var group in groups)
        {
            viewModels.Add(new CategorySummaryViewModel()
            {
                Category = group.Category ?? "Unknown",
                Count = group.Count
            });
        }

        return viewModels;
    }
}
