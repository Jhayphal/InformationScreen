using Newtonsoft.Json;

namespace InformationScreen.Services;

public class WeatherHistory
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

    [JsonProperty("hourly_units", Required = Required.Always)]
    public HourlyUnits? HourlyUnits { get; set; }

    [JsonProperty("hourly", Required = Required.Always)]
    public Hourly? Hourly { get; set; }
    
    public static WeatherHistory? FromJson(string json) => JsonConvert.DeserializeObject<WeatherHistory>(json, Converter.Settings);
}

public class Hourly
{
    [JsonProperty("time", Required = Required.Always)]
    public string[]? Time { get; set; }

    [JsonProperty("temperature_2m", Required = Required.Always)]
    public double[]? Temperature2M { get; set; }

    [JsonProperty("relativehumidity_2m", Required = Required.Always)]
    public long[]? RelativeHumidity2M { get; set; }

    [JsonProperty("precipitation_probability", Required = Required.Always)]
    public long[]? PrecipitationProbability { get; set; }

    [JsonProperty("rain", Required = Required.Always)]
    public double[]? Rain { get; set; }

    [JsonProperty("snowfall", Required = Required.Always)]
    public long[]? Snowfall { get; set; }

    [JsonProperty("cloudcover_low", Required = Required.Always)]
    public long[]? CloudCoverLow { get; set; }

    [JsonProperty("windspeed_10m", Required = Required.Always)]
    public double[]? WindSpeed10M { get; set; }
}

public class HourlyUnits
{
    [JsonProperty("time", Required = Required.Always)]
    public string? Time { get; set; }

    [JsonProperty("temperature_2m", Required = Required.Always)]
    public string? Temperature2M { get; set; }

    [JsonProperty("relativehumidity_2m", Required = Required.Always)]
    public string? RelativeHumidity2M { get; set; }

    [JsonProperty("precipitation_probability", Required = Required.Always)]
    public string? PrecipitationProbability { get; set; }

    [JsonProperty("rain", Required = Required.Always)]
    public string? Rain { get; set; }

    [JsonProperty("snowfall", Required = Required.Always)]
    public string? Snowfall { get; set; }

    [JsonProperty("cloudcover_low", Required = Required.Always)]
    public string? CloudCoverLow { get; set; }

    [JsonProperty("windspeed_10m", Required = Required.Always)]
    public string? WindSpeed10M { get; set; }
}