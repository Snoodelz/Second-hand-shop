using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWebShop.Models.ExternalAPI
{
    public class WeatherData
    {
        public Datum[] data { get; set; }
        public int count { get; set; }
    }

    public class Datum
    {
        public Weather weather { get; set; }
        public double temp { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
    }
}
