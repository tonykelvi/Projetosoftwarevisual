using System;

namespace tk
{
    public class Pessoa
    {
        public string nome {get; set;}
        public DateTime nasc {get; set;}
    }
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
