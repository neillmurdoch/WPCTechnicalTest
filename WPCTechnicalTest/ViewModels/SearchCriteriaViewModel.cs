using System.ComponentModel.DataAnnotations;

namespace WPCTechnicalTest.ViewModels;

public class SearchCriteriaViewModel
{
    [Required(ErrorMessage = "A valid UK latitude must be between 49 and 61"), Range(49.0, 61.0)]
    public string? Latitude { get; set; }

    [Required(ErrorMessage = "A valid UK longitude must be between -8 and 2"), Range(-8.0, 2.0)]
    public string? Longitude { get; set; }
    
    [Required(ErrorMessage = "A month in the last year must be provided")]
    public string? Date { get; set; }
}
