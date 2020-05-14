using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class IpLocationModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string CityName {get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZipCode { get; set; }
        public string TimeZone { get; set; }
        public string ISP { get; set; }
        public string DomainName { get; set; }
        public int CreditsConsumed { get; set; }
    }
}