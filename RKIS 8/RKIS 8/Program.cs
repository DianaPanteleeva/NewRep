using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;


internal class Program
{
  private static string defaultCityFileName = "city.txt";
  
  public static void Main(string[] args)
  {
    string defaultcity = GetDefaultCity();
    Console.WriteLine("Погода для города по умолчанию: " + defaultcity);
    Console.WriteLine("Хотите ли вы вывести погоду для города по умолчанию? (да/нет) ");
    string response = Console.ReadLine();
    if (response.ToLower() == "да")
    {
      DisplayWeather(defaultcity);
    }
    else
    {
      Console.WriteLine("Введите название города, погоду которого хотите узнать");
      string gorod = Console.ReadLine();
      DisplayWeather(gorod);
    }
    Console.WriteLine("Хотите изменить город по умолчанию? (да/нет)");
    string changeCity = Console.ReadLine();
    if (changeCity.ToLower() == "да")
    {
      Console.WriteLine("Введите новый город по умолчанию");
      string newCity = Console.ReadLine();
      SaveDefaultCity(newCity);
    }
  }

  static string GetDefaultCity()
  {
    try
    {
      if (File.Exists(defaultCityFileName))
      {
        return File.ReadAllText(defaultCityFileName);
      }
      else
      {
        Console.WriteLine("Введите город по умолчанию: ");
        string city = Console.ReadLine();
        File.WriteAllText(defaultCityFileName, city);
        return city;
      }
    }
    catch (Exception ex)  //обработка исключений при чтении файла.
    {
      Console.WriteLine($"Ошибка при чтнении файла : {{ex.Message}}");
      return "Unknown";
    }
  }


  static void SaveDefaultCity(string city)
  {
    File.WriteAllText(defaultCityFileName, city);
  }
  static void DisplayWeather(string cityName)
  {
    string APIkey = "b966beb6ba5103282e9a7f0725cb9f55";
    string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={APIkey}&units=metric";
    try
    {
      using (WebClient client = new WebClient())
      {
        string json = client.DownloadString(url);
        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
        Console.WriteLine($"погода в городе {weatherData.Name} на текущий момент:");
        Console.WriteLine($"температура: {weatherData.Main.Temp}\u00b0C ");
        Console.WriteLine($"влажность: {weatherData.Main.Humidity}%");
        Console.WriteLine($"скорость ветра: {weatherData.Wind.Speed} м/с ");
      }
    }
    catch (Exception ex)  //обработка исключений при загрузке данных о погоде
    {
      Console.WriteLine($"Ошибка при получении данных о погоде: {ex.Message}");
    }
  }
public class WeatherData
  {
    public string Name { get; set; }
    public MainData Main { get; set; }
    public WindData Wind { get; set; }
  }

  public class MainData
  {
    public float Temp { get; set; }
    public int Humidity { get; set; }

  }

  public class WindData
  {
    public float Speed { get; set; }
  }
}