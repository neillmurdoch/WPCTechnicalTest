using System.ComponentModel.DataAnnotations;

namespace WPCTechnicalTest.ViewModels;

public class CrimeSearchCriteriaViewModel
{
    [Required(ErrorMessage = "The UK latitude value must be provided between 49 and 61"), Range(49, 61)]
    public string? Latitude { get; set; }

    [Required(ErrorMessage = "The UK longitude value must be provided between -8 and 2"), Range(-8, 2)]
    public string? Longitude { get; set; }
    
    [Required(ErrorMessage = "A month in the last year must be provided")]
    public string? Date { get; set; }
}
