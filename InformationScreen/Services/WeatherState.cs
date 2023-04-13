using System;
using Newtonsoft.Json;

namespace InformationScreen.Services;

public class WeatherState
{
    [JsonProperty("latitude", Required = Required.Always)]
    public double Latitude { get; set; }

    [JsonProperty("longitude", Required = Required.Always)]
    public double Longitude { get; set; }

    [JsonProperty("generationtime_ms", Required = Required.Always)]
    public double GenerationTimeMs { get; set; }

    [JsonProperty("utc_offset_seconds", Required = Required.Always)]
    public long UtcOffsetSeconds { get; set; }

    [JsonProperty("timezone", Required = Required.Always)]
    public string? Timezone { get; set; }

    [JsonProperty("timezone_abbreviation", Required = Required.Always)]
    public string? TimezoneAbbreviation { get; set; }

    [JsonProperty("elevation", Required = Required.Always)]
    public long Elevation { get; set; }

    [JsonProperty("current_weather", Required = Required.Always)]
    public CurrentWeather? CurrentWeather { get; set; }

    [JsonProperty("daily_units", Required = Required.Always)]
    public DailyUnits? DailyUnits { get; set; }

    [JsonProperty("daily", Required = Required.Always)]
    public Daily? Daily { get; set; }
    
    public static WeatherState? FromJson(string json) => JsonConvert.DeserializeObject<WeatherState>(json, Converter.Settings);
}

public class CurrentWeather
{
    [JsonProperty("temperature", Required = Required.Always)]
    public double Temperature { get; set; }

    [JsonProperty("windspeed", Required = Required.Always)]
    public double WindSpeed { get; set; }

    [JsonProperty("winddirection", Required = Required.Always)]
    public long WindDirection { get; set; }

    [JsonProperty("weathercode", Required = Required.Always)]
    public long WeatherCode { get; set; }

    [JsonProperty("is_day", Required = Required.Always)]
    public long IsDay { get; set; }

    [JsonProperty("time", Required = Required.Always)]
    public string? Time { get; set; }
}

public class Daily
{
    [JsonProperty("time", Required = Required.Always)]
    public DateTimeOffset[]? Time { get; set; }

    [JsonProperty("temperature_2m_max", Required = Required.Always)]
    public double[]? Temperature2MMax { get; set; }

    [JsonProperty("temperature_2m_min", Required = Required.Always)]
    public double[]? Temperature2MMin { get; set; }

    [JsonProperty("windspeed_10m_max", Required = Required.Always)]
    public double[]? WindSpeed10MMax { get; set; }
}

public class DailyUnits
{
    [JsonProperty("time", Required = Required.Always)]
    public string? Time { get; set; }

    [JsonProperty("temperature_2m_max", Required = Required.Always)]
    public string? Temperature2MMax { get; set; }

    [JsonProperty("temperature_2m_min", Required = Required.Always)]
    public string? Temperature2MMin { get; set; }

    [JsonProperty("windspeed_10m_max", Required = Required.Always)]
    public string? WindSpeed10MMax { get; set; }
}