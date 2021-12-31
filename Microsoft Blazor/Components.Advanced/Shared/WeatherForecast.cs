namespace Components.Advanced.Shared;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    //public int TemperatureF => TemperatureC > 0 ? 32 + (int)(TemperatureC / 0.5556) : throw new DivideByZeroException();
}
