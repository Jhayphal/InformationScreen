using System;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InformationScreen.Services;

public static class MoneyRateInfo
{
  private static readonly Lazy<HttpClient> Client = new();

  public static async Task<Valute?> GetActual(string currency)
  {
    var allRates = await GetActual();

    return allRates?.Valute?.FirstOrDefault(x => string.Equals(x.CharCode, currency, StringComparison.OrdinalIgnoreCase));
  }

  public static async Task<Valutes?> GetActual() => await GetActual(Client.Value, DateTime.Now);

  public static async Task<Valutes?> GetActual(HttpClient client, DateTime date)
  {
    var request = $"https://cbr.ru/scripts/XML_daily.asp?date_req={date.Day:00}/{date.Month:00}/{date.Year:0000}";
    try
    {
      using var response = await client.GetAsync(request);
      response.EnsureSuccessStatusCode();
      
      await using var responseStream = await response.Content.ReadAsStreamAsync();
      using var streamReader = new StreamReader(responseStream, Encoding.ASCII);
      
      var xmlResponse = await streamReader.ReadToEndAsync();
      if (string.IsNullOrWhiteSpace(xmlResponse))
      {
        return null;
      }

      XmlSerializer serializer = new XmlSerializer(typeof(Valutes));
      using StringReader reader = new StringReader(xmlResponse);
      return (Valutes)serializer.Deserialize(reader)!;
    }
    catch (Exception e)
    {
      System.Diagnostics.Debug.WriteLine(e.Message);
      return null;
    }
  }
}