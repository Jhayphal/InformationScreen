using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InformationScreen.Services;

public static class CoinRateInfo
{
  private static readonly Lazy<HttpClient> Client = new();

  public static async Task<BitcoinExchangeRates?> GetActual(string currency)
  {
    var allRates = await GetActual();
    if (allRates is null)
    {
      return null;
    }

    return allRates.TryGetValue(currency.ToUpper(), out var rate) ? rate : null;
  }

  public static async Task<Dictionary<string, BitcoinExchangeRates>?> GetActual() => await GetActual(Client.Value);

  public static async Task<Dictionary<string, BitcoinExchangeRates>?> GetActual(HttpClient client)
  {
    try
    {
      var jsonResponse =
        await client.GetStringAsync(
          "https://blockchain.info/ru/ticker"); // https://www.blockchain.com/ru/api/exchange_rates_api
      return BitcoinExchangeRates.FromJson(jsonResponse);
    }
    catch (Exception e)
    {
      System.Diagnostics.Debug.WriteLine(e.Message);
      return null;
    }
  }
}