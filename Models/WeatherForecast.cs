using System;

namespace net_5
{
    public class WeatherForecast
    {
        public int WeatherForecastID {get; set;}
        public string Summary { get; set; }
        public int TemperatureC { get; set; }
        public int? TemperatureF {get; set; }
        public DateTime Date { get; set; }
    }
}
