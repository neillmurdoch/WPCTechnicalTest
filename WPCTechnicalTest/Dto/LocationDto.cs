using System.Text.Json.Serialization;

namespace WPCTechnicalTest.Dto;

public class LocationDto
{
    [JsonPropertyName("latitude")] public string? Latitude { get; set; }
    [JsonPropertyName("longitude")] public string? Longitude { get; set; }
    [JsonPropertyName("street")] public StreetDto? Street { get; set; }
}
