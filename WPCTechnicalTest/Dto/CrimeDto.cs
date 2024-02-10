using System.Text.Json.Serialization;

namespace WPCTechnicalTest.Dto;

public class CrimeDto
{

    [JsonPropertyName("category")] public string? Category { get; set; }
    [JsonPropertyName("context")] public string? Context { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("location")] public LocationDto? Location { get; set; }
    [JsonPropertyName("location_subtype")] public string? LocationSubtype { get; set; }
    [JsonPropertyName("location_type")] public string? LocationType { get; set; }
    [JsonPropertyName("month")] public string? Month { get; set; }
    [JsonPropertyName("outcome_status")] public object? OutcomeStatus { get; set; }
    [JsonPropertyName("persistent_id")] public string? PersistentId { get; set; }

    //public string category { get; set; }
    //public string context { get; set; }
    //public int id { get; set; }
    //public LocationDto location { get; set; }
    //public string location_subtype { get; set; }
    //public string location_type { get; set; }
    //public string month { get; set; }
    //public object outcome_status { get; set; }
    //public string persistent_id { get; set; }

}