using System.Text.Json.Serialization;

namespace BlazorBlog.Models;

public class OpenMeteoApiResponse
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("generationtime_ms")]
    public double GenerationTimeMs { get; set; }

    [JsonPropertyName("utc_offset_seconds")]
    public int UtcOffsetSeconds { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("timezone_abbreviation")]
    public string? TimezoneAbbreviation { get; set; }

    [JsonPropertyName("elevation")]
    public double Elevation { get; set; }

    [JsonPropertyName("current_weather")]
    public CurrentWeather? CurrentWeather { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("temperature")]
    public double Temperature { get; set; } // Default is Celsius

    [JsonPropertyName("windspeed")]
    public double Windspeed { get; set; } // Default is km/h

    [JsonPropertyName("winddirection")]
    public double WindDirection { get; set; } // Degrees

    [JsonPropertyName("weathercode")]
    public int WeatherCode { get; set; } // WMO Weather interpretation codes

    [JsonPropertyName("is_day")]
    public int IsDay { get; set; } // 1 for day, 0 for night

    [JsonPropertyName("time")]
    public string? Time { get; set; } // ISO8601 timestamp
}

// A class to hold the processed, displayable weather data (can be reused or adapted)
public class ProcessedOpenMeteoData
{
    public DateTime ObservationTime { get; set; }
    public double TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public double WindSpeedKmh { get; set; }
    public double WindSpeedMph => WindSpeedKmh * 0.621371;
    public string WindDirectionCardinal { get; set; } = "N/A";
    public string WeatherDescription { get; set; } = "N/A";
    public bool IsDay { get; set; }
}