using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class WeatherReportModel
    {
        public Coordinates Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Temperatures Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Cloud Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int TimeZone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class Cloud
    {
        public int All { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public class Coordinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class Temperatures
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
