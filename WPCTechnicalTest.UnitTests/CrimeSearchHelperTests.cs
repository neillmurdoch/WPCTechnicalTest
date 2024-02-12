using WPCTechnicalTest.Dto;
using WPCTechnicalTest.Helpers;
using WPCTechnicalTest.ViewModels;

namespace WPCTechnicalTest.UnitTests;

public class CrimeSearchHelperTests
{
    private readonly ICrimeSearchHelper _crimeSearchHelper;

    public CrimeSearchHelperTests()
    {
        _crimeSearchHelper = new CrimeSearchHelper();
    }

    #region MapResultsToCategorySummaryViewModels

    [Fact]
    public void MapResultsToCategorySummaryViewModels_NullResultsPassed_EmptyListReturned()
    {
        // Arrange
        List<CrimeDto>? crimeResults = null;

        // Act
        var result = _crimeSearchHelper.MapResultsToCategorySummaryViewModels(crimeResults);

        // Assert
        result.Should().BeOfType<List<CategorySummaryViewModel>>().And.HaveCount(0);
    }
    
    [Fact]
    public void MapResultsToCategorySummaryViewModels_EmptyResultsPassed_EmptyListReturned()
    {
        // Arrange
        List<CrimeDto>? crimeResults = new();

        // Act
        var result = _crimeSearchHelper.MapResultsToCategorySummaryViewModels(crimeResults);

        // Assert
        result.Should().BeOfType<List<CategorySummaryViewModel>>().And.HaveCount(0);
    }

    [Fact]
    public void MapResultsToCategorySummaryViewModels_SingleCrimePassed_SingleSummaryReturned()
    {
        // Arrange
        List<CrimeDto>? crimeResults = new()
        {
            new CrimeDto()
            {
                Category = "Category 1"
            }
        };

        // Act
        var result = _crimeSearchHelper.MapResultsToCategorySummaryViewModels(crimeResults);

        // Assert
        result.Should().BeOfType<List<CategorySummaryViewModel>>().And.HaveCount(1);
    }

    [Fact]
    public void MapResultsToCategorySummaryViewModels_TwoCrimesInSameCategoryPassed_SingleSummaryReturned()
    {
        // Arrange
        List<CrimeDto>? crimeResults = new()
        {
            new CrimeDto()
            {
                Category = "Category 1"
            },
            new CrimeDto()
            {
                Category = "Category 1"
            }
        };

        // Act
        var result = _crimeSearchHelper.MapResultsToCategorySummaryViewModels(crimeResults);

        // Assert
        result.Should().BeOfType<List<CategorySummaryViewModel>>().And.HaveCount(1);
    }
    
    [Fact]
    public void MapResultsToCategorySummaryViewModels_TwoCrimesInDifferentCategoriesPassed_TwoSummariesReturned()
    {
        // Arrange
        List<CrimeDto>? crimeResults = new()
        {
            new CrimeDto()
            {
                Category = "Category 1"
            },
            new CrimeDto()
            {
                Category = "Category 2"
            }
        };

        // Act
        var result = _crimeSearchHelper.MapResultsToCategorySummaryViewModels(crimeResults);

        // Assert
        result.Should().BeOfType<List<CategorySummaryViewModel>>().And.HaveCount(2);
    }


    #endregion
}
