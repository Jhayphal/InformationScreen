using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InformationScreen.Services;

public static class WeatherInfo
{
  private static readonly Lazy<HttpClient> Client = new();

  public static async Task<WeatherState?> GetActual() => await GetActual(Client.Value);

  public static async Task<WeatherState?> GetActual(HttpClient client)
  {
    var request = $"https://api.open-meteo.com/v1/forecast?latitude=46.61&longitude=39.25&daily=temperature_2m_max,temperature_2m_min,windspeed_10m_max&current_weather=true&windspeed_unit=ms&forecast_days=1&timezone=Europe%2FMoscow";
    try
    {
      var jsonResponse = await client.GetStringAsync(request);
      return WeatherState.FromJson(jsonResponse);
    }
    catch (Exception e)
    {
      System.Diagnostics.Debug.WriteLine(e.Message);
      return null;
    }
  }

  public static async Task<WeatherHistory?> GetHourlyForDay() => await GetHourlyForDay(Client.Value);
  
  public static async Task<WeatherHistory?> GetHourlyForDay(HttpClient client)
  {
    var request = $"https://api.open-meteo.com/v1/forecast?latitude=46.61&longitude=39.25&hourly=temperature_2m,relativehumidity_2m,precipitation_probability,rain,snowfall,cloudcover_low,windspeed_10m&current_weather=true&windspeed_unit=ms&forecast_days=1&timezone=Europe%2FMoscow";
    try
    {
      var jsonResponse = await client.GetStringAsync(request);
      return WeatherHistory.FromJson(jsonResponse);
    }
    catch (Exception e)
    {
      System.Diagnostics.Debug.WriteLine(e.Message);
      return null;
    }
  }
}