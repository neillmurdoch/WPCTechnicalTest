using WPCTechnicalTest.Dto;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.Helpers;

public interface ICrimeSearchHelper
{
    List<CategorySummaryViewModel> MapResultsToCategorySummaryViewModels(List<CrimeDto>? results);
}
