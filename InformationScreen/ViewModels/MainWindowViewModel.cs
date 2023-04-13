using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InformationScreen.Services;
using ReactiveUI;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace InformationScreen.ViewModels;

public class SeriesDateDoubleItem
{
  public DateTime X { get; set; }
  public double Y { get; set; }
}

public class MainWindowViewModel : ViewModelBase
{
  private string btcRate = "загрузка...";
  private string usdRate = "загрузка...";
  private string temperature = "загрузка...";

  public MainWindowViewModel()
  {
    MyModel = new PlotModel { Title = "BTC" };
    
    var maximum = DateTime.Today;
    var minimum = maximum.AddDays(-7);

    MyModel.Axes.Add(new DateTimeAxis
    {
      Position = AxisPosition.Bottom,
      Minimum = DateTimeAxis.ToDouble(minimum),
      Maximum = DateTimeAxis.ToDouble(maximum),
      StringFormat = "dd.MM.yy"
    });

    MyModel.Axes.Add(new LinearAxis
    {
      Position = AxisPosition.Right,
      Minimum = 24000,
      Maximum = 31000,
      StringFormat = "### ###",
      MajorGridlineStyle = LineStyle.Solid,
      MajorStep = 1000
    });

    var random = new Random();
    var items = new List<SeriesDateDoubleItem>();
    while (minimum <= maximum)
    {
      items.Add(new SeriesDateDoubleItem
      {
        X = minimum, 
        Y = random.NextDouble() * 7000d + 24000d
      });
      
      minimum = minimum.AddDays(1);
    }
    
    MyModel.Series.Add(new LineSeries
    {
      ItemsSource = items, 
      DataFieldX = nameof(SeriesDateDoubleItem.X), 
      DataFieldY = nameof(SeriesDateDoubleItem.Y),
      MarkerType = MarkerType.Circle
    });

    CoinRateInfo.GetActual("USD").ContinueWith(SetBtcRate);
    MoneyRateInfo.GetActual("USD").ContinueWith(SetUsdRate);
    WeatherInfo.GetActual().ContinueWith(SetTemperature);
  }

  public PlotModel MyModel { get; private set; }

  public string BtcRate
  {
    get => $"BTC: {btcRate}";
    set => this.RaiseAndSetIfChanged(ref btcRate, value);
  }

  public string UsdRate
  {
    get => $"USD: {usdRate}";
    set => this.RaiseAndSetIfChanged(ref usdRate, value);
  }

  public string Temperature
  {
    get => $"{temperature} \u00b0C";
    set => this.RaiseAndSetIfChanged(ref temperature, value);
  }

  private void SetBtcRate(Task<BitcoinExchangeRates?> task)
    => BtcRate = task.Result is null ? "Ошибка загрузки" : $"${task.Result.Last.ToString("### ### ###").Trim()}";

  private void SetUsdRate(Task<Valute?> task)
    => UsdRate = task.Result is null ? "Ошибка загрузки" : $"₽{task.Result.Value}";

  private void SetTemperature(Task<WeatherState?> task)
    => Temperature = task.Result is null ? "Ошибка загрузки" : task.Result.CurrentWeather?.Temperature.ToString("F1")!;
}