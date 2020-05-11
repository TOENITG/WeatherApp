using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WeatherApp.Data
{
    public class WeatherAtLocationService
    {
        private string _IPAddress;
        private string _Location;
        private string _CurrentWeather;
        public string GetClientIPAdress()
        {
            _IPAddress = GetClientIPAdress();
            return null;
        }
        public string GetClientLocation(string IPAddress)
        {
            _Location = "";
            return null;
        }
        public string GetClientCurrentWeather(string Location)
        {
            return null;
        }
    }
}
