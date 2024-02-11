using System.Diagnostics.CodeAnalysis;

namespace WPCTechnicalTest.Dto;

[ExcludeFromCodeCoverage]
public class SearchCriteriaDto
{
    public string? Latitude { get; set; } = default;
    public string? Longitude { get; set; } = default;
    public string? Date { get; set; } = default;
}
