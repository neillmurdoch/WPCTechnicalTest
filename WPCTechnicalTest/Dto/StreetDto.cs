﻿using System.Text.Json.Serialization;

namespace WPCTechnicalTest.Dto;

public class StreetDto
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
}
