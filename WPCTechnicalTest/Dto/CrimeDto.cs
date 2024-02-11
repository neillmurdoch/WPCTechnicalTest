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
}