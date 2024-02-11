using System.Text.Json.Serialization;

namespace WPCTechnicalTest.Dto;

public class LastCrimeDateDto
{
    [JsonPropertyName("date")] public DateTime LastCrimeDate { get; set; }
}
