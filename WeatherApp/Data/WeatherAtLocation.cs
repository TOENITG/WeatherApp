using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class WeatherAtLocation
    {
        public string IPAddress { get; set; }
        public string Location { get; set; }
        public string CurrentWeather { get; set; }
    }
}
